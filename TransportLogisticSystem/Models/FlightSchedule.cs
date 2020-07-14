using System;
namespace TransportLogisticSystem.Models
{
    public class FlightSchedule
    {
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Day { get; set; }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {DepartureCity}, arrival: {ArrivalCity}, day: {Day}";
        }
    }
}
