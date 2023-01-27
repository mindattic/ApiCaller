using APICaller.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace APICaller
{
    public class ReadAPI
    {
        private string BaseURL;

        public ReadAPI(string baseURL)
        {
            BaseURL = baseURL;
        }

        public T Get<T>(string id)
        {
            var url = $@"{BaseURL}{id}";

            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("X-Token-Key", "APICaller");
                var response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return default(T);

                var content = response.Content;
                if (string.IsNullOrWhiteSpace(content))
                    return default(T);

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {

            }

            return default(T);
        }

    }
}
