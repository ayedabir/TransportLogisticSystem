using System;
using System.Collections.Generic;

namespace TransportLogisticSystem.Utilities
{
    public interface IFileReader
    {
        List<string> ReadLines(string filePath);
        string ReadAll(string filePath);
    }
}
