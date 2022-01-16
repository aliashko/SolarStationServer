using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SolarStationServer.DataAccess.Entities;

namespace SolarStationServer.DataAccess
{
    public class SolarStationDbContext : DbContext
    {
        public DbSet<ReportEntity> Reports { get; set; }

        public DbSet<SettingEntity> Settings { get; set; }

        private IOptionsMonitor<SolarStationDbOptions> SolarStationDbOptionsMonitor { get; }

        public SolarStationDbContext(DbContextOptions<SolarStationDbContext> options, IOptionsMonitor<SolarStationDbOptions> solarStationDbOptionsMonitor)
            : base(options)
        {
            SolarStationDbOptionsMonitor = solarStationDbOptionsMonitor;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                var connectionString = SolarStationDbOptionsMonitor.CurrentValue.ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
