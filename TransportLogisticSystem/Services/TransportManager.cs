using System;
using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public class TransportManager<T> : ITransportManager<T>
    {

        private readonly IFileLoader<T> loader;
        private readonly IPrinter printer;
        public TransportManager(IFileLoader<T> loader, IPrinter printer)
        {
            this.loader = loader;
            this.printer = printer;
        }

        public IEnumerable<T> Load(string filePath)
        {
            return loader.Load(filePath);
        }

        public void Print(IEnumerable<T> schedules)
        {
            foreach (var schedule in schedules)
                printer.Print(schedule);
        }
    }
}
