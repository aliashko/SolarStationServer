using Newtonsoft.Json;

namespace SolarStationServer.Models.Api
{
    public class PostDataModel
    {
        [JsonProperty("ts")]
        public ulong Timestamp { get; set; }

        [JsonProperty("t")]
        public int Temperature { get; set; }

        [JsonProperty("h")]
        public uint Humidity { get; set; }

        [JsonProperty("r")]
        public uint RaindropLevel { get; set; }

        [JsonProperty("sv")]
        public uint SolarVoltage { get; set; }

        [JsonProperty("sc")]
        public uint SolarCurrent { get; set; }

        [JsonProperty("bv")]
        public uint BatteryVoltage { get; set; }

        [JsonProperty("av")]
        public uint ArduinoVoltage { get; set; }

        [JsonProperty("gv")]
        public uint GsmVoltage { get; set; }

        [JsonProperty("pm")]
        public PowerMode PowerMode { get; set; }

        [JsonProperty("rc")]
        public ulong RestartsCount { get; set; }

        [JsonProperty("ge")]
        public uint GsmErrors { get; set; }
    }
}
