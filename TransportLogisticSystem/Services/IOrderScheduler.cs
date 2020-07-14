using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem.Services
{
    public interface IOrderScheduler
    {
        IEnumerable<Order> Schedule(IEnumerable<Order> orders, IEnumerable<FlightSchedule> schedules, int flightCapacity = 20);
    }
}