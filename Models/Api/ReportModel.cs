using Newtonsoft.Json;
using SolarStationServer.Models.Api;

namespace SolarStationServer.DataAccess.Entities
{
    public class ReportModel
    {
        [JsonProperty("ts")]
        public ulong Timestamp { get; set; }

        [JsonProperty("t")]
        public int Temperature { get; set; }

        [JsonProperty("h")]
        public int Humidity { get; set; }

        [JsonProperty("r")]
        public int RaindropLevel { get; set; }

        [JsonProperty("sm")]
        public int SoilMoistureLevel { get; set; }

        [JsonProperty("gl")]
        public int GsmSignalLevel { get; set; }

        [JsonProperty("sv")]
        public int SolarVoltage { get; set; }

        [JsonProperty("sc")]
        public int SolarCurrent { get; set; }

        [JsonProperty("bv")]
        public int BatteryVoltage { get; set; }

        [JsonProperty("av")]
        public int ArduinoVoltage { get; set; }

        [JsonProperty("gv")]
        public int GsmVoltage { get; set; }

        [JsonProperty("pm")]
        public PowerMode PowerMode { get; set; }

        [JsonProperty("rc")]
        public long RestartsCount { get; set; }

        [JsonProperty("ge")]
        public int GsmErrors { get; set; }
    }
}
