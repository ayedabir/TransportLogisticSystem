using System;

namespace TransportLogisticSystem
{
    public class ConsolePrinter: IPrinter
    {
        public void Print<T>(T objectToPrint)
        {
            Console.WriteLine(objectToPrint);
        }
    }
}
