using System;
namespace TransportLogisticSystem.Models
{
    public class Order
    {
        public string Number { get; set; }
        public string Destination { get; set; }
        public FlightSchedule FlightSchedule { get; set; }

        public override string ToString()
        {
            return FlightSchedule != null ?
                $"order: {Number}, , flightNumber: {FlightSchedule.FlightNumber}, departure: {FlightSchedule.DepartureCity}, arrival: {FlightSchedule.ArrivalCity}, day: {FlightSchedule.Day}" :
                $"order: {Number}, flightNumber: not scheduled";
        }
    }
}
