using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EN.ConsoleApp.Model;
using Newtonsoft.Json;

namespace EN.ConsoleApp.DAL
{
    public class StationListDAL
    {
        string stationUrl = ConfigurationManager.AppSettings["EarthNetworks.Stations.Api.BaseAddress"];
        string stationCall = ConfigurationManager.AppSettings["EarthNetworks.Stations.Api.BaseAddress.Call"];

        public async Task<StationResponse> GetAllStations()
        {
            var stgStations = new StationResponse();
            try {
                HttpClient _client = new HttpClient();
                _client.BaseAddress = new Uri(stationUrl);
                _client.Timeout = TimeSpan.FromMinutes(120);
                var stationList = await _client.GetAsync(stationUrl + "/data/stations/v1/all").ConfigureAwait(false);
                stgStations = JsonConvert.DeserializeObject<StationResponse>(stationList.Content.ReadAsStringAsync().Result);

            }
            catch (Exception)
            {

            }
           
            return stgStations;
        }
    }
}
