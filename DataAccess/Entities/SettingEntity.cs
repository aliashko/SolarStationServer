using System.ComponentModel.DataAnnotations;

namespace SolarStationServer.DataAccess.Entities
{
    public class SettingEntity
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
