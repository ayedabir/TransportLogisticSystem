using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TransportLogisticSystem.Utilities;

namespace TransportLogisticSystem.UnitTests
{
    [TestFixture()]
    public class ScheduleLoaderTest
    {
        private ScheduleLoader scheduleLoader;
        private Mock<IFileReader> fileReaderMock;
        private IFixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
            fileReaderMock = fixture.Freeze<Mock<IFileReader>>();
            scheduleLoader = fixture.Create<ScheduleLoader>();
        }

        [Test()]
        public void TestLoadingEmptyFile()
        {
            var path = fixture.Create<string>();
            fileReaderMock.Setup(mock => mock.ReadLines(It.IsAny<string>())).Returns(new List<string>());

            var result = scheduleLoader.Load(path);

            Assert.IsEmpty(result);
            fileReaderMock.Verify(mock => mock.ReadLines(path), Times.Once);
        }


        [Test()]
        public void TestloadingAFileWithSchedules()
        {
            var path = fixture.Create<string>();
            var line1 = "Day 1:";
            var line2 = "Flight 1: Montreal airport (YUL) to Toronto (YYZ)";
            fileReaderMock.Setup(mock => mock.ReadLines(It.IsAny<string>()))
                .Returns(new List<string> { line1,line2});

            var result = scheduleLoader.Load(path).ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.FirstOrDefault()?.FlightNumber);
            Assert.AreEqual("YUL", result.FirstOrDefault()?.DepartureCity);
            Assert.AreEqual("YYZ", result.FirstOrDefault()?.ArrivalCity);
            fileReaderMock.Verify(mock => mock.ReadLines(path), Times.Once);
        }
    }
}
