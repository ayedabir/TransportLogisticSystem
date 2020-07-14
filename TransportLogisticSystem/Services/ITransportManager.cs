using System;
using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public interface ITransportManager<T>
    {
        IEnumerable<T> Load(string filePath);
        void Print(IEnumerable<T> schedules);
    }
}
