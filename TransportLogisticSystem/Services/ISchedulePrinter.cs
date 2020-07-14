using System;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public interface ISchedulePrinter
    {
        void PrintSchedule(FlightSchedule schedule);
    }
}
