using Microsoft.EntityFrameworkCore;
using SolarStationServer.DataAccess.Entities;
using SolarStationServer.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarStationServer.DataAccess
{
    public class SolarStationDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        //public DbSet<Setting> Settings { get; set; }

        public SolarStationDbContext(DbContextOptions<SolarStationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
