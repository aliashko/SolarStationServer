using SolarStationServer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarStationServer.Repositories
{
    public interface IReportsRepository
    {
        Task<bool> StoreReport(ReportModel reportModel);
    }
}
