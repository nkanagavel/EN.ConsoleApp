using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices;
using Microsoft.Exchange.WebServices.Data;

namespace EN.ConsoleApp.DAL
{
    public class emailModule
    {
        ExchangeService exchange = null;

        public emailModule()
        {

        }

        public void ConnectToExchangeServer()
        {
            try
            {
                exchange = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                exchange.Credentials = new WebCredentials("KNagaraj@earthnetworks.com", "3eRevuva");
                exchange.AutodiscoverUrl("KNagaraj@earthnetworks.com", RedirectionCallback);
                //var emailCollection = exchange.GetRoomLists();

                var foundItems = exchange.FindItems(WellKnownFolderName.Contacts, new ItemView(10000));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exchange Error :{ex.Message.ToString() ?? ex.InnerException.Message.ToString()}");
                Console.ReadLine();
            }
        }

        static bool RedirectionCallback(string url)
        {
            // Return true if the URL is an HTTPS URL.
            return url.ToLower().StartsWith("https://");
        }
    }
}
