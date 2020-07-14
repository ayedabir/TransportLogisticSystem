using System;
using System.IO;
using System.Linq;
using DryIoc;
using TransportLogisticSystem.Models;
using TransportLogisticSystem.Services;
using TransportLogisticSystem.Utilities;

namespace TransportLogisticSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Transport logistic system");
            var container = GetConatiner();

            var scheduleManager = container.Resolve<ITransportManager<FlightSchedule>>();
            Console.WriteLine("Please provide the path for the flight schedule file");
            var filePath = Console.ReadLine();
            var schedules = scheduleManager.Load(filePath);
            scheduleManager.Print(schedules);

            var orderManager = container.Resolve<ITransportManager<Order>>();
            Console.WriteLine("Please provide the path for the orders file");
            filePath = Console.ReadLine();
            var orders = orderManager.Load(filePath);

            var orderScheduler = container.Resolve<IOrderScheduler>();
            var ordersScheduled = orderScheduler.Schedule(orders, schedules);

            orderManager.Print(ordersScheduled);
            Console.ReadLine();
        }

        private static IContainer GetConatiner()
        {
            IContainer container = new Container();

            container.Register<IPrinter, ConsolePrinter>();
            container.Register<IFileReader, FileReader>();
            container.Register<IFileLoader<FlightSchedule>, ScheduleLoader>();
            container.Register<ITransportManager<FlightSchedule>, TransportManager<FlightSchedule>>();
            container.Register<IFileLoader<Order>, OrderLoader>();
            container.Register<ITransportManager<Order>, TransportManager<Order>>();
            container.Register<IOrderScheduler, OrderScheduler>();
            return container;
        }
    }
}
