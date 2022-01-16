using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SolarStationServer.Contracts;
using SolarStationServer.Repositories;
using System.IO;
using System.Threading.Tasks;

namespace SolarStationServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IReportsRepository ReportsRepository;
        private readonly ISettingsRepository SettingsRepository;

        public ApiController(IReportsRepository reportsRepository, ISettingsRepository settingsRepository, ILogger<ApiController> logger)
        {
            ReportsRepository = reportsRepository;
            SettingsRepository = settingsRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> GetSettings()
        {
            var settings = await SettingsRepository.GetSettings();   
            return JsonConvert.SerializeObject(settings);
        }

        [HttpPost]
        public async Task<string> PostData(ReportModel postDataModel)
        {
            var result = await ReportsRepository.StoreReport(postDataModel);

            var settings = await SettingsRepository.GetSettings();
            var data = new SettingsModel
            {
                LightTimeSleepDurationSeconds = settings.LightTimeSleepDurationSeconds,
                DarkTimeSleepDurationSeconds = settings.DarkTimeSleepDurationSeconds,
                SendDataFrequency = settings.SendDataFrequency,
                //SendSupplementalDataFrequency = settings.SendSupplementalDataFrequency,
                ResetSendDataCounterAfterFailure = (uint)(settings.ResetSendDataCounterAfterFailure ? 1 : 0),
                SafeModeVoltage = (uint)(settings.SafeModeVoltage * 10),
                EconomyModeVoltage = (uint)(settings.EconomyModeVoltage * 10),
                EconomyModeDataSendSkipMultiplier = settings.EconomyModeDataSendSkipMultiplier,
                SolarVoltageForLightTime = (uint)(settings.SolarVoltageForLightTime * 10),
                Version = settings.Version
            };

            var serializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            using (var writer = new JsonTextWriter(stringWriter))
            {
                writer.QuoteName = false;
                serializer.Serialize(writer, data);
            }
            var json = stringWriter.ToString();

            return json;
        }
    }
}
