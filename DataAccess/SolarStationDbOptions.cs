using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarStationServer.DataAccess
{
    public class SolarStationDbOptions
    {
        public const string ConfigurationDefaultKey = "dataAccess";

        public string ConnectionString { get; set; }
    }
}
