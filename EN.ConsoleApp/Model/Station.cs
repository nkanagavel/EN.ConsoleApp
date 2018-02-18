using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.Model
{
    public class Station
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string StationId { get; set; }
        public string StationName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? ElevationAboveSeaLevelMeters { get; set; }
        public string TimeZone { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipCode { get; set; }
        public string DmaCode { get; set; }
        public string DmaName { get; set; }
        public int? OrganizationId { get; set; }
    }
}
