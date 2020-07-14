using System;
using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public interface IScheduleLoader
    {
        IEnumerable<FlightSchedule> LoadSchedule(string filePath);
    }
}
