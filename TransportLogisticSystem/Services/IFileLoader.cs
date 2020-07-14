using System;
using System.Collections.Generic;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public interface IFileLoader<T>
    {
        IEnumerable<T> Load(string filePath);
    }
}
