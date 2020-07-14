using System;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public class SchedulePrinter: ISchedulePrinter
    {
        public void PrintSchedule(FlightSchedule schedule)
        {
            Console.WriteLine(schedule);
        }
    }
}
