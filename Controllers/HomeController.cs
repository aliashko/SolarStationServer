using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarStationServer.Repositories;
using System.Threading.Tasks;

namespace SolarStationServer.Controllers
{
    [Controller]
    [Route("")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IReportsRepository ReportsRepository;
        private readonly ISettingsRepository SettingsRepository;

        public HomeController(IReportsRepository reportsRepository, ISettingsRepository settingsRepository, ILogger<ApiController> logger)
        {
            ReportsRepository = reportsRepository;
            SettingsRepository = settingsRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reports = await ReportsRepository.GetLastReports();

            return View(reports);
        }
    }
}
