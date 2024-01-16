using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorsel_programalama_odev_iki.Services
{
    public class RateService
    {
        public static async Task<string> GetAltinDovizGuncelKurlar()
        {
            HttpClient client = new HttpClient();
            string url = "https://api.genelpara.com/embed/altin.json";
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsondata = await response.Content.ReadAsStringAsync();
            return jsondata;
        }
    }
}
