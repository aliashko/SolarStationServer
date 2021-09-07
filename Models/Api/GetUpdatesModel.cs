using Newtonsoft.Json;

namespace SolarStationServer.Models.Api
{
    public class GetUpdatesModel
    {
        [JsonProperty("lsd")]
        public uint LightTimeSleepDurationSeconds { get; set; }
            
        [JsonProperty("dsd")]
        public uint DarkTimeSleepDurationSeconds { get; set; }

        [JsonProperty("sdf")]
        public uint SendDataFrequency { get; set; }

        [JsonProperty("smv")]
        public uint SafeModeVoltage { get; set; }

        [JsonProperty("emv")]
        public uint EconomyModeVoltage { get; set; }

        [JsonProperty("emm")]
        public uint EconomyModeDataSendSkipMultiplier { get; set; }

        [JsonProperty("svl")]
        public uint SolarVoltageForLightTime { get; set; }

        [JsonProperty("ver")]
        public uint Version { get; set; }
    }
}
