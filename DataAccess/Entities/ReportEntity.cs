using System;
using System.ComponentModel.DataAnnotations;

namespace SolarStationServer.DataAccess.Entities
{
    public class ReportEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long Timestamp { get; set; }

        public decimal Temperature { get; set; }

        public decimal Humidity { get; set; }

        public int RaindropLevel { get; set; }

        public int SoilMoistureLevel { get; set; }

        public int GsmSignalLevel { get; set; }

        public decimal SolarVoltage { get; set; }

        public decimal SolarCurrent { get; set; }

        public decimal BatteryVoltage { get; set; }

        public decimal ArduinoVoltage { get; set; }

        public decimal GsmVoltage { get; set; }

        public int PowerMode { get; set; }

        public int? SimMoneyBalance { get; set; }

        public long RestartsCount { get; set; }

        public int GsmErrors { get; set; }
    }
}
