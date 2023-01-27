using APICaller.Models;
using CSVApp;
using System.Collections.Concurrent;
using System.Data;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using Application = System.Windows.Forms.Application;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using System.Windows.Forms;
using APICaller.Extensions;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace APICaller
{
    public partial class frmMain : Form
    {
        string BASE_URL = "https://api.artic.edu/api/v1/artworks/";
        ConcurrentBag<string> output;

        FileWriter fileWriter = new FileWriter("C:\\Users\\ryand\\OneDrive\\Desktop\\APICaller\\APICaller\\results.csv");

        DataTable table;

        int tableSize = 0;
        int emptyCellCount = 0;
        int noResponseCount = 0;
        int chunkSize;
        int threadCount;
        int pingRate;
        int requests = 0;
        int averageRequests = 0;

        TimeSpan elapsed;

        Stopwatch watch = new Stopwatch();

        const string TAB = "     ";


        List<int> IDList = new List<int>();

        #region Windows Form Events

        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            openFileDialog.FileName = txtFile.Text;
            OpenFile();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFile();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }


        private void OpenFile()
        {
            if (string.IsNullOrWhiteSpace(openFileDialog.FileName)) return;

            txtFile.Text = openFileDialog.FileName;
            var csv = new ReadCSV(openFileDialog.FileName);
            table = csv.Table;

            try
            {
                dataGridView.DataSource = table;
                tableSize = table.Rows.Count * table.Columns.Count;
                lblTableSize.Text = tableSize.ToString("N0");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion


        private void ParseDataTable()
        {
            IDList = new List<int>();
            foreach (DataRow row in table.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    int id = int.TryParse(cell?.ToString(), out id) ? id : 0;
                    if (id > 0)
                        IDList.Add(id);
                }
            }
        }

        private void Generate()
        {
            if (table == null)
            {
                MessageBox.Show("You must load a CSV file.", "Error");
                return;
            }

            chunkSize = int.TryParse(txtChunkSize.Text, out chunkSize) ? chunkSize : 1000;
            threadCount = int.TryParse(txtPingRate.Text, out threadCount) ? threadCount : -1;
            pingRate = int.TryParse(txtPingRate.Text, out pingRate) ? pingRate : 200;

            ParseDataTable();

            if (rdoDefault.Checked)
                Process();
            else if (rdoParallelForEach.Checked)
                ProcessParallel();
            else if (rdoAsync.Checked)
                ProcessAsync();
        }

        private void Process()
        {
            emptyCellCount = 0;
            noResponseCount = 0;
            requests = 0;

            string url = "https://api.artic.edu/api/v1/artworks/";
            var api = new ReadAPI(url);

            txtOutput.Text = "";
            lblLog.Text = "";

            watch.Start();
            foreach (DataRow row in table.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    string? id = cell?.ToString();
                    if (string.IsNullOrWhiteSpace(id) || !IsNumeric(id))
                    {
                        emptyCellCount++;
                        continue;
                    }

                    var response = api.Get<ArcticResponse>(id);
                    if (response == null || response.data == null || string.IsNullOrWhiteSpace(response.data.title))
                    {
                        noResponseCount++;
                        continue;
                    }

                    tableSize = (table.Rows.Count * table.Columns.Count) - noResponseCount;
                    requests++;

                    WriteLine(id, response.data.title);
                }
            }
            watch.Stop();

            //output.Write(txtOutput.Text.Replace(TAB, ","));
        }

        private void WriteLine(string? id, string? title, bool updateLog = true)
        {
            string text = $"{id}{TAB}{title}{TAB}{Environment.NewLine}";
            txtOutput.AppendText(text);

            if (!updateLog) return;

            elapsed = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

            string log
                = $"Count:      {TAB}{requests:N0} request{PluralSuffix(requests)} over {elapsed:hh\\:mm\\:ss}{Environment.NewLine}"
                + $"Empty Cells:{TAB}{emptyCellCount:N0}{Environment.NewLine}"
                + $"No Response:{TAB}{noResponseCount:N0}{Environment.NewLine}";

            requestsPerMinute++;
            if ((int)elapsed.TotalSeconds % 60 == 0)
            {
                metrics.Add(requestsPerMinute);
                requestsPerMinute = 0;
                averageRequests = (int)metrics.Average();
            }
            if (elapsed.TotalSeconds >= 60)
                log += $"Metrics:    {TAB}~{averageRequests * 60:N0} requests per hour or ~{averageRequests * 60 * 8:N0} requests per 8 hours";

            lblLog.Text = log;
        }

        int requestsPerMinute = 0;
        List<int> metrics = new List<int>();

        private string PluralSuffix(int count)
        {
            return count == 1 ? "" : "s";
        }

        private bool IsNumeric(string s)
        {
            return int.TryParse(s, out _);
        }

      
        private void PrintResults()
        {
            Debug.Write(string.Join(Environment.NewLine, output));
            Debug.WriteLine($"INFO:{TAB}{requests:N0} requests completed in {elapsed:hh\\:mm\\:ss}{Environment.NewLine}");

            if (elapsed.Seconds > 0 && elapsed.Seconds < 60)
            {
                float multiplier = 60 / elapsed.Seconds;
                Debug.WriteLine($"INFO:{TAB}{requests * multiplier:N0} requests completed per minute");
                Debug.WriteLine($"INFO:{TAB}{requests * multiplier * 60:N0} requests completed in 1 hour");
                Debug.WriteLine($"INFO:{TAB}{requests * multiplier * 60 * 2:N0} requests completed in 2 hours");
                Debug.WriteLine($"INFO:{TAB}{requests * multiplier * 60 * 3:N0} requests completed in 3 hours");
                Debug.WriteLine($"INFO:{TAB}{requests * multiplier * 60 * 8:N0} requests completed in 8 hours{Environment.NewLine}");
            }
        }

        private void ProcessParallel()
        {
            HttpClient httpClient = new HttpClient();

            //Convert list into chunks
            var chunks = IDList.ChunkBy(chunkSize);

            output = new ConcurrentBag<string>();
            watch.Reset();
            watch.Start();
            requests = 0;
            Debug.WriteLine($"INFO:{TAB}Starting {IDList.Count:N0} parallel requests...");
            foreach (var chunk in chunks)
            {
                Parallel.ForEach(chunk, new ParallelOptions() { MaxDegreeOfParallelism = threadCount }, (id, state, index) =>
                {
                    try
                    {
                        Interlocked.Increment(ref requests);
                        if (requests % pingRate == 0)
                            Debug.WriteLine($"INFO:{TAB}{requests} requests completed in {TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds):hh\\:mm\\:ss}");

                        var url = $@"{BASE_URL}{id}";
                        var response = httpClient.GetAsync(url).Result;
                        if (response == null || !response.IsSuccessStatusCode || response.Content == null) return;
                        var content = response.Content.ReadAsStringAsync().Result;
                        if (string.IsNullOrWhiteSpace(content)) return;
                        var rs = JsonConvert.DeserializeObject<ArcticResponse>(content);
                        if (rs == null || rs.data == null || string.IsNullOrWhiteSpace(rs.data.title)) return;

                        output.Add($"#{requests}{TAB}ID: {id}{TAB}Title: {rs.data.title}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                });
            }

            watch.Stop();

            elapsed = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

            PrintResults();

        }



        public async void ProcessAsync()
        {

            output = new ConcurrentBag<string>();
            watch.Reset();
            watch.Start();
            requests = 0;

            List<Task> tasks = new List<Task>();
            foreach (var id in IDList)
            {
                tasks.Add(GetAsync(id));
            }

            await Task.WhenAll(tasks.ToArray());

            watch.Stop();

            elapsed = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

            PrintResults();
        }






        private async Task GetAsync(int id)
        {
            try
            {


                var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient();

                Interlocked.Increment(ref requests);
                if (requests % pingRate == 0)
                    Debug.WriteLine($"INFO:{TAB}{requests} requests completed in {TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds):hh\\:mm\\:ss}");

                var url = $@"{BASE_URL}{id}";

                var response = await httpClient.GetAsync(url);
                if (response == null || !response.IsSuccessStatusCode || response.Content == null) return;
                var content = response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrWhiteSpace(content)) return;
                var rs = JsonConvert.DeserializeObject<ArcticResponse>(content);
                if (rs == null || rs.data == null || string.IsNullOrWhiteSpace(rs.data.title)) return;


                output.Add($"#{requests}{TAB}ID: {id}{TAB}Title: {rs.data.title}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }


        ////https://devblogs.microsoft.com/pfxteam/implementing-a-simple-foreachasync/
        //public static Task ForEachAsync<TSource, TResult>(
        //    this IEnumerable<TSource> source,
        //    Func<TSource, Task<TResult>> taskSelector, Action<TSource, TResult> resultProcessor)
        //{
        //    var oneAtATime = new SemaphoreSlim(initialCount: 1, maxCount: 1);
        //    return Task.WhenAll(
        //        from item in source
        //        select ProcessAsync(item, taskSelector, resultProcessor, oneAtATime));
        //}

        //private static async Task ProcessAsync<TSource, TResult>(
        //    TSource item,
        //    Func<TSource, Task<TResult>> taskSelector, Action<TSource, TResult> resultProcessor,
        //    SemaphoreSlim oneAtATime)
        //{
        //    TResult result = await taskSelector(item);
        //    await oneAtATime.WaitAsync();
        //    try { resultProcessor(item, result); }
        //    finally { oneAtATime.Release(); }
        //}

    }
}