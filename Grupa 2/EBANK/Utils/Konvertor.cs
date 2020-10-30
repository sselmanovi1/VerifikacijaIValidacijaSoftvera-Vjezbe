using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EBANK.Utils
{
    public class Konvertor
    {

        public async Task<float> konvertujDevizuAsync(float iznos, string izValute, string uValutu)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://data.fixer.io/api/latest" +
                    "?access_key=ba8e84f219054816408d7814d5b43b0c");

                var result = await client.GetAsync("");
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var rates = JsonConvert.DeserializeXNode(response, "a").Root.Element("rates");
                    var from = float.Parse(rates.Element(izValute).Value);
                    var to = float.Parse(rates.Element(uValutu).Value);
                    return iznos * to / from;
                }
            }

            return 0;
        }
    }
}
