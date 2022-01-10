using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoAngularPractico.Models
{
    public class CryptoRepository
    {
        private List<cryptomoneda> cryptos = new List<cryptomoneda>();

        public CryptoRepository()
        {
           
        }

        public string GetAllCryptomonedas(string Api_key)
        {
            String res = "";
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "10";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", Api_key);
            client.Headers.Add("Accepts", "application/json");
            try
            {
                res = client.DownloadString(URL.ToString());
            }
            catch(WebException ex)
            {
                res = "{ \"message\": \"" + ex.Message + "\" }";
            }
            return res;

        }
    }
}
