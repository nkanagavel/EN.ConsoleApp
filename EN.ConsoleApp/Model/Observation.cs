using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EN.ConsoleApp.Model
{
    public class Observation
    {
        public string StationId { get; set; }
        public string ProviderId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int IconCode { get; set; }
        public string ElevationAboveSeaLevelMeters { get; set; }
        public string TimeZone { get; set; }
        public string ObservationTimeUtc { get; set; }
        public string DewPointC { get; set; }
        public string DewPointCRatePerHour { get; set; }
        public string Humidity { get; set; }
        [JsonProperty("Humidity-QcDataDescriptor")]
        public string HumidityQcDataDescriptor { get; set; }
        public string HumidityRatePerHour { get; set; }
        [JsonProperty("HumidityRatePerHour-QcDataDescriptor")]
        public string HumidityRatePerHourQcDataDescriptor { get; set; }
        public string Light { get; set; }
        [JsonProperty("Light-QcDataDescriptor")]
        public string LightQcDataDescriptor { get; set; }

        public string LightRatePerHour { get; set; }
        [JsonProperty("LightRatePerHour-QcDataDescriptor")]
        public string LightRatePerHourQcDataDescriptor { get; set; }
        public string PressureSeaLevelMBar { get; set; }
        [JsonProperty("PressureSeaLevelMBar-QcDataDescriptor")]
        public string PressureSeaLevelMBarQcDataDescriptor { get; set; }
        public string PressureSeaLevelMBarRatePerHour { get; set; }
        [JsonProperty("PressureSeaLevelMBarRatePerHour-QcDataDescriptor")]
        public string PressureSeaLevelMBarRatePerHourQcDataDescriptor { get; set; }
        public string RainMillimetersDaily { get; set; }
        [JsonProperty("RainMillimetersDaily-QcDataDescriptor")]
        public string RainMillimetersDailyQcDataDescriptor { get; set; }
        public string RainMillimetersRatePerHour { get; set; }
        [JsonProperty("RainMillimetersRatePerHour-QcDataDescriptor")]
        public string RainMillimetersRatePerHourQcDataDescriptor { get; set; }
        public string RainMillimetersMonthly { get; set; }
        [JsonProperty("RainMillimetersMonthly-QcDataDescriptor")]
        public string RainMillimetersMonthlyQcDataDescriptor { get; set; }
        public string RainMillimetersYearly { get; set; }
        [JsonProperty("RainMillimetersYearly-QcDataDescriptor")]
        public string RainMillimetersYearlyQcDataDescriptor { get; set; }
        public string TemperatureC { get; set; }
        [JsonProperty("TemperatureC-QcDataDescriptor")]
        public string TemperatureCQcDataDescriptor { get; set; }
        public string TemperatureCRatePerHour { get; set; }
        [JsonProperty("TemperatureCRatePerHour-QcDataDescriptor")]
        public string TemperatureCRatePerHourQcDataDescriptor { get; set; }
        public string FeelsLike { get; set; }
        public string WindSpeedKph { get; set; }
        [JsonProperty("WindSpeedKph-QcDataDescriptor")]
        public string WindSpeedKphQcDataDescriptor { get; set; }
        public string WindDirectionDegrees { get; set; }
        [JsonProperty("WindDirectionDegrees-QcDataDescriptor")]
        public string WindDirectionDegreesQcDataDescriptor { get; set; }
        public string WindSpeedKphAvg { get; set; }
        [JsonProperty("WindSpeedKphAvg-QcDataDescriptor")]
        public string WindSpeedKphAvgQcDataDescriptor { get; set; }
        public string WindDirectionDegreesAvg { get; set; }
        [JsonProperty("WindDirectionDegreesAvg-QcDataDescriptor")]
        public string WindDirectionDegreesAvgQcDataDescriptor { get; set; }
        public string WindGustKphHourly { get; set; }
        [JsonProperty("WindGustKphHourly-QcDataDescriptor")]
        public string WindGustKphHourlyQcDataDescriptor { get; set; }
        public string WindGustTimeUtcHourly { get; set; }
        public string WindGustDirectionDegreesHourly { get; set; }
        [JsonProperty("WindGustDirectionDegreesHourly-QcDataDescriptor")]
        public string WindGustDirectionDegreesHourlyQcDataDescriptor { get; set; }
        public string WindGustKphDaily { get; set; }
        [JsonProperty("WindGustKphDaily-QcDataDescriptor")]
        public string WindGustKphDailyQcDataDescriptor { get; set; }
        public string WindGustTimeUtcDaily { get; set; }
        public string WindGustDirectionDegreesDaily { get; set; }
        [JsonProperty("WindGustDirectionDegreesDaily-QcDataDescriptor")]
        public string WindGustDirectionDegreesDailyQcDataDescriptor { get; set; }
        public string HumidityHigh { get; set; }
        [JsonProperty("HumidityHigh-QcDataDescriptor")]
        public string HumidityHighQcDataDescriptor { get; set; }
        public string HumidityHighUtc { get; set; }
        public string HumidityLow { get; set; }
        [JsonProperty("HumidityLow-QcDataDescriptor")]
        public string HumidityLowQcDataDescriptor { get; set; }
        public string HumidityLowUtc { get; set; }
        public string LightHigh { get; set; }
        [JsonProperty("LightHigh-QcDataDescriptor")]
        public string LightHighQcDataDescriptor { get; set; }
        public string LightHighUtc { get; set; }
        public string LightLow { get; set; }
        [JsonProperty("LightLow-QcDataDescriptor")]
        public string LightLowQcDataDescriptor { get; set; }
        public string LightLowUtc { get; set; }
        public string PressureSeaLevelHighMBar { get; set; }
        [JsonProperty("PressureSeaLevelHighMBar-QcDataDescriptor")]
        public string PressureSeaLevelHighMBarQcDataDescriptor { get; set; }
        public string PressureSeaLevelHighUtc { get; set; }
        public string PressureSeaLevelLowMBar { get; set; }
        [JsonProperty("PressureSeaLevelLowMBar-QcDataDescriptor")]
        public string PressureSeaLevelLowMBarQcDataDescriptor { get; set; }
        public string PressureSeaLevelLowUtc { get; set; }
        public string RainRateMaxMmPerHour { get; set; }
        [JsonProperty("RainRateMaxMmPerHour-QcDataDescriptor")]
        public string RainRateMaxMmPerHourQcDataDescriptor { get; set; }
        public string RainRateMaxUtc { get; set; }
        public string TemperatureHighC { get; set; }
        [JsonProperty("TemperatureHighC-QcDataDescriptor")]
        public string TemperatureHighCQcDataDescriptor { get; set; }
        public string TemperatureHighUtc { get; set; }
        public string TemperatureLowC { get; set; }
        [JsonProperty("TemperatureLowC-QcDataDescriptor ")]
        public string TemperatureLowCQcDataDescriptor { get; set; }
        public string TemperatureLowUtc { get; set; }

    }
}
