using SolarStationServer.Contracts;
using SolarStationServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarStationServer.Repositories
{
    public interface IReportsRepository
    {
        Task<List<ReportDto>> GetLastReports(int count = 100);

        Task<bool> StoreReport(ReportModel reportModel);
    }
}
