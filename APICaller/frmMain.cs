using APICaller.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.InteropServices;

namespace APICaller
{
    public partial class frmMain : Form
    {
        // IHttpClientFactory clientFactory;
        private static HttpClient httpClient = new HttpClient();


        public frmMain()
        {
            //var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            //clientFactory = serviceProvider.GetService<IHttpClientFactory>();


            InitializeComponent();
        }

        private string TimeStamp => $"{TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds):hh\\:mm\\:ss}";

        Logger _log;
        Statistics _stats;

        //FileWriter fileWriter = new FileWriter("C:\\Users\\ryand\\OneDrive\\Desktop\\APICaller\\APICaller\\results.csv");

        DataTable table = new DataTable();
        string baseURL = string.Empty;
        int tableSize = 0;
        int threadCount = 0;
        int pingRate = 0;
        int requests = 0;
        int taskDelay = 0;

        TimeSpan elapsed;
        Stopwatch watch = new Stopwatch();
        const string TAB = "     ";
        List<int> IDList = new List<int>();

        #region Windows Form Events

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void frmMain_Load(object sender, EventArgs e)
        {
            AllocConsole();
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

        #endregion

        private void OpenFile()
        {
            if (string.IsNullOrWhiteSpace(openFileDialog.FileName)) return;

            txtFile.Text = openFileDialog.FileName;
            var csv = new ReadCSV(openFileDialog.FileName, false);
            table = csv.Table;

            try
            {
                //TODO: System.Exception: 'Sum of the columns' FillWeight values cannot exceed 65535.'


                if (chkPreviewCSV.Checked)
                    dataGridView.DataSource = table;

                tableSize = table.Rows.Count * table.Columns.Count;
                lblTableSize.Text = tableSize.ToString("N0");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

            //Assign options based on form elements
            baseURL = txtBaseURL.Text;
            pingRate = int.TryParse(txtPingRate.Text, out pingRate) ? pingRate : 200;
            threadCount = int.TryParse(txtThreadCount.Text, out threadCount) ? threadCount : 3;
            taskDelay = int.TryParse(txtTaskDelay.Text, out taskDelay) ? taskDelay : 1;

            ParseDataTable();
            ProcessAsync();
        }

        public async void ProcessAsync()
        {
            //Initialize
            _log.Clear();
            _stats.Clear();
            watch.Reset();
            watch.Start();

            var tasks = new List<Task>();
         
            var throttler = new SemaphoreSlim(threadCount);

            WriteLine($"{Environment.NewLine}{TimeStamp}{TAB}Starting...");

            foreach (var id in IDList)
            {
                await throttler.WaitAsync();
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var response = await GetAsync(id);
                        if (response == null || !response.IsSuccessStatusCode || response.Content == null)
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                                _stats.NotFound();
                            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                                _stats.BadRequest();

                            _log.Error($"Request failed: ID: {id}{TAB}{response.StatusCode.ToString()}", id);
                            return;
                        }

                        var content = response.Content.ReadAsStringAsync().Result;
                        if (string.IsNullOrWhiteSpace(content)) return;
                        var rs = JsonConvert.DeserializeObject<ArcticResponse>(content);
                        if (rs == null || rs.data == null || string.IsNullOrWhiteSpace(rs.data.title)) return;

                        _log.Success($"ID: {id}{TAB}Title: {rs.data.title}", id);
                        _stats.Success();

                        if (pingRate > 0)
                        {
                            Interlocked.Increment(ref requests);
                            if (requests % pingRate == 0)
                                WriteLine($"{TimeStamp}{TAB}{requests} requests completed in {TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds):hh\\:mm\\:ss}");
                        }

                        // let's wait here for X to honor the API's rate limit                         
                        await Task.Delay(taskDelay);
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.Message, -1);
                        _stats.Exception();
                    }
                    finally
                    {
                        throttler.Release();
                    }

                }));
            }

            // await for all the tasks to complete
            await Task.WhenAll(tasks.ToArray());

            WriteLine($"{Environment.NewLine}{TimeStamp}{TAB}Done.");

            //Finalize
            watch.Stop();
            elapsed = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);
            PrintResults();
        }

        private async Task<HttpResponseMessage> GetAsync(int id)
        {
            return await httpClient.GetAsync($"{baseURL}{id}");
        }

        private void PrintResults()
        {
            var successLog = _log.Items.OrderBy(x => x.ID).Where(x => x.Type == LogItemType.Success).Select(x => x.Message).ToList();
            var errorLog = _log.Items.OrderBy(x => x.ID).Where(x => x.Type == LogItemType.Error).Select(x => x.Message).ToList();

            WriteLine();
            Write(string.Join(Environment.NewLine, successLog));
            WriteLine();
            WriteLine();
            Write($"INFO:{TAB}{requests:N0} requests completed in {elapsed:hh\\:mm\\:ss}");
            WriteLine();
            WriteLine();
            Write(string.Join(Environment.NewLine, errorLog));
            WriteLine();

            //Print Metrics
            if (elapsed.Seconds > 0 && elapsed.Seconds < 60)
            {
                float multiplier = 60 / elapsed.Seconds;
                WriteLine($"INFO:{TAB}{requests * multiplier:N0} requests completed per minute");
                WriteLine($"INFO:{TAB}{requests * multiplier * 60:N0} requests completed in 1 hour");
                WriteLine($"INFO:{TAB}{requests * multiplier * 60 * 2:N0} requests completed in 2 hours");
                WriteLine($"INFO:{TAB}{requests * multiplier * 60 * 3:N0} requests completed in 3 hours");
                WriteLine($"INFO:{TAB}{requests * multiplier * 60 * 8:N0} requests completed in 8 hours");
                WriteLine();
            }

            var ids = _log.Items.OrderBy(x => x.ID).Where(x => x.Type == LogItemType.Success).Select(x => x.ID).ToList();
            Write(string.Join(',', ids));

        }


        private string PluralSuffix(int count)
        {
            return count == 1 ? "" : "s";
        }

        private bool IsNumeric(string s)
        {
            return int.TryParse(s, out _);
        }


        private void Write(string s = "")
        {
            Console.Out.WriteAsync(s);
        }

        private void WriteLine(string s = "")
        {
            Console.Out.WriteAsync($"{s}{Environment.NewLine}");
        }

    }
}