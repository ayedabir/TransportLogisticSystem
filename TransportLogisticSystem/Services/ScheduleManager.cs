using System;
using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public class ScheduleManager : IScheduleManager
    {

        private readonly IScheduleLoader scheduleLoader;
        private readonly ISchedulePrinter schedulePrinter;
        public ScheduleManager(IScheduleLoader scheduleLoader, ISchedulePrinter schedulePrinter)
        {
            this.scheduleLoader = scheduleLoader;
            this.schedulePrinter = schedulePrinter;
        }

        public IEnumerable<FlightSchedule> LoadFlightSchedules(string filePath)
        {
            return scheduleLoader.LoadSchedule(filePath);
        }

        public void PrintFlightSchedules(IEnumerable<FlightSchedule> schedules)
        {
            foreach (var schedule in schedules)
                schedulePrinter.PrintSchedule(schedule);
        }
    }
}
