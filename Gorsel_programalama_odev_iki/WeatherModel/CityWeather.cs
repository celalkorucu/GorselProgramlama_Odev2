using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorsel_programalama_odev_iki.WeatherModel
{
   public class CityWeather
    {
        public string Name { get; set; }
        public string Source => $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={Name}&basla=1&bitir=5&rC=111&rZ=fff";
    }
}
