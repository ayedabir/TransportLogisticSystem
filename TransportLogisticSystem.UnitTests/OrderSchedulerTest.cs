using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TransportLogisticSystem.Models;
using TransportLogisticSystem.Services;
using TransportLogisticSystem.Utilities;

namespace TransportLogisticSystem.UnitTests
{
    [TestFixture()]
    public class OrderSchedulerTest
    {
        private OrderScheduler scheduler;
        private Mock<IFileReader> fileReaderMock;
        private IFixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
            scheduler = fixture.Create<OrderScheduler>();
        }

        [Test()]
        public void TestScheduling()
        {
            var schedules = fixture.CreateMany<FlightSchedule>(2);
            var orders = fixture.CreateMany<Order>(5);
            foreach(var schedule in schedules)
            {
                schedule.ArrivalCity = "YUL";
            }
            foreach (var order in orders)
            {
                order.Destination = "YUL";
                order.FlightSchedule = null;
            }

            var result = scheduler.Schedule(orders, schedules, 2).ToList();

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(4, result.Where(order => order.FlightSchedule != null).Count());
            Assert.AreEqual(1, result.Where(order => order.FlightSchedule == null).Count());
        }
    }
}
