using Newtonsoft.Json;
using SolarStationServer.Models.Api;
using System;
using System.ComponentModel.DataAnnotations;

namespace SolarStationServer.DataAccess.Entities
{
    public class Report
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public ulong Timestamp { get; set; }

        public float Temperature { get; set; }

        public float Humidity { get; set; }

        public int RaindropLevel { get; set; }

        public int SoilMoistureLevel { get; set; }

        public int GsmSignalLevel { get; set; }

        public float SolarVoltage { get; set; }

        public float SolarCurrent { get; set; }

        public float BatteryVoltage { get; set; }

        public float ArduinoVoltage { get; set; }

        public float GsmVoltage { get; set; }

        public int PowerMode { get; set; }

        public long RestartsCount { get; set; }

        public int GsmErrors { get; set; }
    }
}
