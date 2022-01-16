using Newtonsoft.Json;

namespace SolarStationServer.Models
{
    public class Settings
    {
        public uint LightTimeSleepDurationSeconds { get; set; }
            
        public uint DarkTimeSleepDurationSeconds { get; set; }

        public uint SendDataFrequency { get; set; }

        public uint SendSupplementalDataFrequency { get; set; }

        public bool ResetSendDataCounterAfterFailure { get; set; }

        public float SafeModeVoltage { get; set; }

        public float EconomyModeVoltage { get; set; }

        public uint EconomyModeDataSendSkipMultiplier { get; set; }

        public float SolarVoltageForLightTime { get; set; }

        public uint Version { get; set; }
    }
}
