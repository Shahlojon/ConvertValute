using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertValute.Models
{
    public class CurrencyGetValute
    {
        
        public Key Get(string currency, DateTime date)
        {
            string url = "https://alif.tj/api/currency/index.php?currency=" + currency + "&date=" + date.ToString("yyyy-MM-dd");
            var responseString = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                responseString = stream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<Key>(responseString);
        }
    }
}
