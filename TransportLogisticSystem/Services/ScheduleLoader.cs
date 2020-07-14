using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TransportLogisticSystem.Models;
using TransportLogisticSystem.Utilities;

namespace TransportLogisticSystem
{
    public class ScheduleLoader: IFileLoader<FlightSchedule>
    {
        private readonly IFileReader fileReader;
        public ScheduleLoader(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public IEnumerable<FlightSchedule> Load(string filePath) {
            var fileLines = fileReader.ReadLines(filePath);
            List<FlightSchedule> schedules = new List<FlightSchedule>();
            int dayNumber = 0;
            foreach (string line in fileLines)
            {
                string[] lineWords = line.Split(' ');
                if (lineWords.Length == 2 && lineWords[0]== "Day") {
                    dayNumber = ParseDay(lineWords[1]);
                }
                else if (lineWords.Length > 2)
                {
                    var schedule = ParseFlightSchedule(lineWords);
                    schedule.Day = dayNumber;
                    schedules.Add(schedule);
                }
            }
            return schedules;
        }

        private int ParseDay(string dayNumber)
        {
            string[] number = dayNumber.Split(':');
            return int.Parse(number[0].Trim());
        }

        private FlightSchedule ParseFlightSchedule(string[] lineWords)
        {
            var schedule = new FlightSchedule();
            schedule.FlightNumber = int.Parse(lineWords[1].Split(':')[0].Trim());
            var cities = lineWords.Where(word => word[0].Equals('('))
                .Select(word => word.Replace('(',' ').Replace(')', ' ').Trim())
                .ToList();
            schedule.DepartureCity = cities[0];
            schedule.ArrivalCity = cities[1];
            return schedule;
        }
    }
}
