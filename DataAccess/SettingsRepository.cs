using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarStationServer.DataAccess;
using SolarStationServer.Models;
using System;
using System.Threading.Tasks;

namespace SolarStationServer.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        public SettingsRepository(IOptionsMonitor<SolarStationDbOptions> solarStationDbOptionsMonitor)
        {
            SolarStationDbOptionsMonitor = solarStationDbOptionsMonitor;

            SolarStationDbInstance = () => {
                var optionsBuilder = new DbContextOptionsBuilder<SolarStationDbContext>();
                var options = optionsBuilder
                    .UseSqlServer(SolarStationDbOptions.ConnectionString)
                    .Options;

                return new SolarStationDbContext(options, SolarStationDbOptionsMonitor);
            };
        }

        private IOptionsMonitor<SolarStationDbOptions> SolarStationDbOptionsMonitor { get; }

        private SolarStationDbOptions SolarStationDbOptions => SolarStationDbOptionsMonitor.CurrentValue;

        private Func<SolarStationDbContext> SolarStationDbInstance;

        public async Task<Settings> GetSettings()
        {
            using SolarStationDbContext db = SolarStationDbInstance();

            var settingsDictionary = await db.Settings.ToDictionaryAsync(s=>s.Key, s=>s.Value);

            var settingsModel = new Settings
            {
                DarkTimeSleepDurationSeconds = uint.Parse(settingsDictionary["DarkTimeSleepDurationSeconds"]),
                LightTimeSleepDurationSeconds = uint.Parse(settingsDictionary["LightTimeSleepDurationSeconds"]),
                SendDataFrequency = uint.Parse(settingsDictionary["SendDataFrequency"]),
                SendSupplementalDataFrequency = uint.Parse(settingsDictionary["SendSupplementalDataFrequency"]),
                EconomyModeDataSendSkipMultiplier = uint.Parse(settingsDictionary["EconomyModeDataSendSkipMultiplier"]),
                EconomyModeVoltage = float.Parse(settingsDictionary["EconomyModeVoltage"]),
                SafeModeVoltage = float.Parse(settingsDictionary["SafeModeVoltage"]),
                SolarVoltageForLightTime = float.Parse(settingsDictionary["SolarVoltageForLightTime"]),
                ResetSendDataCounterAfterFailure = settingsDictionary["ResetSendDataCounterAfterFailure"] == "1",
                Version = uint.Parse(settingsDictionary["Version"])
            };
            
            return settingsModel;
        }
    }
}
