using System;
using TransportLogisticSystem.Models;

namespace TransportLogisticSystem
{
    public interface IPrinter
    {
        void Print<T>(T objectToPrint);
    }
}
