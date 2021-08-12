using Newtonsoft.Json;

namespace SolarStationServer.Models.Api
{
    public class GetUpdatesModel
    {
        [JsonProperty("lsd")]
        public uint LightTimeSleepDurationInMinutes { get; set; }
            
        [JsonProperty("dsd")]
        public uint DarkTimeSleepDurationInMinutes { get; set; }

        [JsonProperty("sdf")]
        public uint SendDataFrequency { get; set; }

        [JsonProperty("gdf")]
        public uint GetDataFrequency { get; set; }

        [JsonProperty("smv")]
        public uint SafeModeVoltage { get; set; }

        [JsonProperty("emv")]
        public uint EconomyModeVoltage { get; set; }

        [JsonProperty("emm")]
        public uint EconomyModeDataSendSkipMultiplier { get; set; }

        [JsonProperty("svl")]
        public uint SolarVoltageForLightTime { get; set; }

        [JsonProperty("sms")]
        public ulong SmsInformNumber { get; set; }
    }
}
