using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SolarStationServer.Models.Api;
using System.IO;

namespace SolarStationServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetUpdates()
        {
            var data = new GetUpdatesModel
            {
                LightTimeSleepDurationInMinutes = 10,
                DarkTimeSleepDurationInMinutes = 11,
                SendDataFrequency = 12,
                GetDataFrequency = 13,
                SafeModeVoltage = 40,
                EconomyModeVoltage = 45,
                EconomyModeDataSendSkipMultiplier = 2,
                SolarVoltageForLightTime = 50,
                SmsInformNumber = 671759599
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

        [HttpPost]
        public string PostData(PostDataModel postDataModel)
        {
            return postDataModel.Temperature.ToString();
        }
    }
}
