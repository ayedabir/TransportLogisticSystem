using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransportLogisticSystem.Utilities
{
    public class FileReader: IFileReader
    {
        public List<string> ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }

        public string ReadAll(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
