using Newtonsoft.Json;
using Özata_Review.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using System.Windows;
namespace Özata_Review
{
    public class HttpService
    {
        public static string Get(string call)
        {
            string ApiUrl = "http://localhost:51920/api/";
            string result = string.Empty;
            //string userPswd = "$demo" + ":" + "igQqdPY2pjbF6mTvo5WmjBpualiyqxBWgjgkaA0yc8tEo7Kbun7bRnddRvMb";
            //userPswd = Convert.ToBase64String(Encoding.Default.GetBytes(userPswd));
            string baseURL = string.Format("{0}", call);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiUrl);
                    client.Timeout = TimeSpan.FromMinutes(30);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", userPswd);
                    var response = new HttpResponseMessage();
                    response = client.GetAsync(baseURL).Result;
                    result = response.IsSuccessStatusCode ? (response.Content.ReadAsStringAsync().Result) : response.IsSuccessStatusCode.ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hedef makine etkin olarak reddettiğinden bağlantı kurulamadı ");
                Environment.Exit(0);
                throw ex;
            }
        }
        public static void Post(List<ClientLog> clientLog)
        {
            try
            {
                using (var client = new HttpClient()){
                string URI = string.Format("http://localhost:51920/api/ClientLog");

                var serializedClient = JsonConvert.SerializeObject(clientLog);
                var content = new StringContent(serializedClient, Encoding.UTF8, "application/json");
                var result = client.PostAsync(URI, content).Result;


            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hedef makine etkin olarak reddettiğinden bağlantı kurulamadı ");
                Environment.Exit(0);
                throw ex;
            }
        }


    }
        
}
