namespace SolarStationServer.DataAccess
{
    public class SolarStationDbOptions
    {
        public const string ConfigurationDefaultKey = "dataAccess";

        public string ConnectionString { get; set; }
    }
}
