using System;
using System.Collections.Generic;

namespace TransportLogisticSystem.Utilities
{
    public interface IFileReader
    {
        List<string> ReadFile(string filePath);
    }
}
