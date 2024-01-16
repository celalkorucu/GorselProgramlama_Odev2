using Gorsel_programalama_odev_iki.NewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gorsel_programalama_odev_iki.Services
{
    public class NewsService
    {

        public static async Task<Root> GetNews(Category category)
        {
            string apiUrl = "https://api.rss2json.com/v1/api.json?rss_url=" + category.Link;

            try
            {
                string jsonResponse = await GetJsonAsync(apiUrl);

                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    Console.WriteLine(jsonResponse);
                    Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);

                    return root;


                }
                else
                {
                    Console.WriteLine("Empty or null JSON response.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        static async Task<string> GetJsonAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
        }

    }
}
