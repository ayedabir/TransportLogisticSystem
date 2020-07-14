using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransportLogisticSystem.Utilities
{
    public class FileReader: IFileReader
    {
        public List<string> ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
