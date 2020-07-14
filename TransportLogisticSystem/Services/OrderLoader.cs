using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using TransportLogisticSystem.Models;
using TransportLogisticSystem.Utilities;

namespace TransportLogisticSystem.Services
{
    public class OrderLoader: IFileLoader<Order>
    {

        private readonly IFileReader fileReader;
        public OrderLoader(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public IEnumerable<Order> Load(string filePath)
        {
            var text = fileReader.ReadAll(filePath);
            if (string.IsNullOrWhiteSpace(text))
                return new List<Order>();

            var orders = JObject.Parse(text);
            return orders.Properties().Select(item =>
            
                new Order
                {
                    Number = item.Name,
                    Destination = item.Value["destination"].ToObject<string>()
                }
            );
        }
    }
}
