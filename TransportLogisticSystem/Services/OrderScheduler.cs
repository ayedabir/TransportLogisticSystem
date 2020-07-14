using System;
using System.Collections.Generic;
using System.Linq;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem.Services
{
    public class OrderScheduler: IOrderScheduler
    {
        public IEnumerable<Order> Schedule(IEnumerable<Order> orders, IEnumerable<FlightSchedule> schedules, int flightCapacity = 20)
        {
            var groups = orders.GroupBy(order => order.Destination).ToList();
            var scheduledOrders = new List<Order>();
            foreach (var group in groups)
            {
                var groupSchedules = schedules.Where(schedule => schedule.ArrivalCity == group.Key).ToList();
                int numberOfFlightsToOrderDestination = 0;
                foreach (var schedule in groupSchedules)
                {
                    var ordersToSchedule = group.Skip(numberOfFlightsToOrderDestination * flightCapacity)
                                                .Take(flightCapacity).ToList();
                    foreach (var order in ordersToSchedule)
                    {
                        order.FlightSchedule = schedule;
                        scheduledOrders.Add(order);
                    }
                    numberOfFlightsToOrderDestination++;
                }
                if(group.Count() > numberOfFlightsToOrderDestination * flightCapacity)
                    scheduledOrders.AddRange(group.Skip(numberOfFlightsToOrderDestination * flightCapacity));
            }
            return scheduledOrders;
        }
    }
}
