using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SolarStationServer.DataAccess.Entities;
using SolarStationServer.Models.Api;
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

        public ApiController(IReportsRepository reportsRepository, ILogger<ApiController> logger)
        {
            ReportsRepository = reportsRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<string> PostData(ReportModel postDataModel)
        {
            var result = await ReportsRepository.StoreReport(postDataModel);

            var data = new GetUpdatesModel
            {
                LightTimeSleepDurationSeconds = 180,
                DarkTimeSleepDurationSeconds = 1200,
                SendDataFrequency = 1,
                SafeModeVoltage = 37,
                EconomyModeVoltage = 45,
                EconomyModeDataSendSkipMultiplier = 9,
                SolarVoltageForLightTime = 30,
                Version = 2
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
