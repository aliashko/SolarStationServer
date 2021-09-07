using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarStationServer.DataAccess;
using SolarStationServer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarStationServer.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        public ReportsRepository(IOptionsMonitor<SolarStationDbOptions> solarStationDbOptionsMonitor)
        {
            SolarStationDbOptionsMonitor = solarStationDbOptionsMonitor;
        }

        private IOptionsMonitor<SolarStationDbOptions> SolarStationDbOptionsMonitor { get; }

        private SolarStationDbOptions SolarStationDbOptions => SolarStationDbOptionsMonitor.CurrentValue;

        public async Task<bool> StoreReport(ReportModel reportModel)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<SolarStationDbContext>();
                var options = optionsBuilder
                    .UseSqlServer(SolarStationDbOptions.ConnectionString)
                    .Options;

                using SolarStationDbContext db = new SolarStationDbContext(options);
                var report = new Report()
                {
                    Date = DateTime.UtcNow,
                    Timestamp = reportModel.Timestamp,

                    Temperature = (float)reportModel.Temperature / 10,
                    Humidity = (float)reportModel.Humidity / 10,
                    RaindropLevel = reportModel.RaindropLevel,
                    SoilMoistureLevel = reportModel.SoilMoistureLevel,
                    GsmSignalLevel = reportModel.GsmSignalLevel,

                    SolarVoltage = (float)reportModel.SolarVoltage / 100,
                    SolarCurrent = (float)reportModel.SolarCurrent / 100,
                    BatteryVoltage = (float)reportModel.BatteryVoltage / 100,
                    ArduinoVoltage = (float)reportModel.ArduinoVoltage / 100,
                    GsmVoltage = (float)reportModel.GsmVoltage / 100,

                    PowerMode = (int)reportModel.PowerMode,
                    RestartsCount = reportModel.RestartsCount,
                    GsmErrors = reportModel.GsmErrors
                };

                db.Reports.Add(report);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
