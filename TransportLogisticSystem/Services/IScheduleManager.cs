using System;
using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public interface IScheduleManager
    {
        IEnumerable<FlightSchedule> LoadFlightSchedules(string filePath);
        void PrintFlightSchedules(IEnumerable<FlightSchedule> schedules);
    }
}
