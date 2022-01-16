using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarStationServer.Contracts;
using SolarStationServer.DataAccess;
using SolarStationServer.DataAccess.Entities;
using SolarStationServer.Models;
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

        public async Task<List<ReportDto>> GetLastReports(int count = 100)
        {
            using SolarStationDbContext db = SolarStationDbInstance();
            var reports = await db.Reports.Select(r => new ReportDto
            {
                Id = r.Id,
                Date = r.Date,
                Timestamp = r.Timestamp,
                ArduinoVoltage = r.ArduinoVoltage,
                BatteryVoltage = r.BatteryVoltage,
                GsmErrors = r.GsmErrors,
                GsmSignalLevel = r.GsmSignalLevel,
                GsmVoltage = r.GsmVoltage,
                Humidity = r.Humidity,
                PowerMode = (Models.PowerMode)r.PowerMode,
                RaindropLevel = r.RaindropLevel,
                RestartsCount = r.RestartsCount,
                SoilMoistureLevel = r.SoilMoistureLevel,
                SolarCurrent = r.SolarCurrent,
                SolarVoltage = r.SolarVoltage,
                Temperature = r.Temperature,
                SimMoneyBalance = r.SimMoneyBalance
            }).OrderByDescending(r=>r.Id).Take(count).ToListAsync();

            return reports;
        }

        public async Task<bool> StoreReport(ReportModel reportModel)
        {
            try
            {
                using SolarStationDbContext db = SolarStationDbInstance();
                var report = new ReportEntity()
                {
                    Date = DateTime.UtcNow,
                    Timestamp = reportModel.Timestamp,

                    Temperature = (decimal)reportModel.Temperature / 10,
                    Humidity = (decimal)reportModel.Humidity / 10,
                    RaindropLevel = reportModel.RaindropLevel,
                    SoilMoistureLevel = reportModel.SoilMoistureLevel,
                    GsmSignalLevel = reportModel.GsmSignalLevel,

                    SolarVoltage = (decimal)reportModel.SolarVoltage / 100,
                    SolarCurrent = (decimal)reportModel.SolarCurrent / 10,
                    BatteryVoltage = (decimal)reportModel.BatteryVoltage / 100,
                    ArduinoVoltage = (decimal)reportModel.ArduinoVoltage / 100,
                    GsmVoltage = (decimal)reportModel.GsmVoltage / 100,
                    PowerMode = (int)reportModel.PowerMode,

                    SimMoneyBalance = reportModel.SimMoneyBalance,

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
