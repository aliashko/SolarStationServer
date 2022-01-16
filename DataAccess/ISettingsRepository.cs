using SolarStationServer.Models;
using System.Threading.Tasks;

namespace SolarStationServer.Repositories
{
    public interface ISettingsRepository
    {
        Task<Settings> GetSettings();
    }
}
