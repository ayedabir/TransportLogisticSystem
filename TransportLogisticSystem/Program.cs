using System;
using System.IO;
using DryIoc;

namespace TransportLogisticSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Transport logistic system");
            var container = GetConatiner();
            var scheduleManager = container.Resolve<IScheduleManager>();

            Console.WriteLine("Please provide the path for the flight schedule file");
            var filePath = Console.ReadLine();
            var schedules = scheduleManager.LoadFlightSchedules(filePath);
            scheduleManager.PrintFlightSchedules(schedules);
        }

        private static IContainer GetConatiner()
        {
            IContainer container = new Container();

            container.Register<IScheduleLoader, ScheduleLoader>();
            container.Register<ISchedulePrinter, SchedulePrinter>();
            container.Register<IScheduleManager, ScheduleManager>();
            return container;
        }
    }
}
