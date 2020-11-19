using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppriceChecker
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<Models.ItemData> GetItemAsync(string uri)
        {
            Models.ItemData itemData = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    App.f_log("uri is: " + uri);
                    string content = await response.Content.ReadAsStringAsync();
                    App.f_log("API Response: " + content);
                    if (content.Substring(0, 1) == "[")
                    {
                        content = content.Substring(1, content.Length - 2);
                    }
                    itemData = JsonConvert.DeserializeObject<Models.ItemData>(content);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\tERROR {0}", ex.Message);
                App.f_log("rest call error, uri: " + uri);
                App.f_log("rest call error " + ex.Message);
            }

            return itemData;
        }

        public async Task<IEnumerable<Models.ItemData>> GetItemListAsync(string uri)
        {
            IEnumerable<Models.ItemData> itemData = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    App.f_log("uri is: " + uri);
                    string content = await response.Content.ReadAsStringAsync();
                    App.f_log("API Response: " + content);
                    //if (content.Substring(0, 1) == "[")
                    //{
                    //    content = content.Substring(1, content.Length - 2);
                    //}
                    itemData = JsonConvert.DeserializeObject<IEnumerable<Models.ItemData>>(content);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\tERROR {0}", ex.Message);
                App.f_log("rest call error, uri: " + uri);
                App.f_log("rest call error " + ex.Message);
            }

            return itemData;
        }

        public async Task<String> GetItemAdditionAsync(string uri)
        {
            //IEnumerable<Models.ItemData> itemData = null;
            String message = "";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    App.f_log("uri is: " + uri);
                    message = await response.Content.ReadAsStringAsync();
                    App.f_log("API Response: " + message);
                    //if (content.Substring(0, 1) == "[")
                    //{
                    //    content = content.Substring(1, content.Length - 2);
                    //}
                   // itemData = JsonConvert.DeserializeObject<IEnumerable<Models.ItemData>>(content);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("\tERROR {0}", ex.Message);
                App.f_log("rest call error, uri: " + uri);
                App.f_log("rest call error " + ex.Message);
                message = "Error";
            }

            return message;
        }

        //public async Task<string> PostTransAsync(string uri, Models.transaction Transaction)
        //{
        //    string sresponse = null;

        //    try
        //    {
        //        string strans = JsonConvert.SerializeObject(Transaction);

        //        _client.DefaultRequestHeaders
        //            .Accept
        //             .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

        //        var content = new StringContent(JsonConvert.SerializeObject(Transaction), Encoding.UTF8, "application/json");

        //        App.f_log("POST TRANS API header: " + strans);

        //        HttpResponseMessage response = await _client.PostAsync(uri, content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string rcontent = await response.Content.ReadAsStringAsync();
        //            App.f_log("POST TRANS API Response: " + rcontent);
        //            sresponse = rcontent;
        //        }
        //        else
        //        {
        //            App.f_log("POST TRANS API Response NOT SUCCESSFULL");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //        App.f_log("rest call error " + ex.Message);
        //    }

        //    return sresponse;
        //}
    }
}
