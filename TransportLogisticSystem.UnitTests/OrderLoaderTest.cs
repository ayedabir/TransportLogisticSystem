using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TransportLogisticSystem.Services;
using TransportLogisticSystem.Utilities;

namespace TransportLogisticSystem.UnitTests
{
    [TestFixture()]
    public class OrderLoaderTest
    {
        private OrderLoader loader;
        private Mock<IFileReader> fileReaderMock;
        private IFixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
            fileReaderMock = fixture.Freeze<Mock<IFileReader>>();
            loader = fixture.Create<OrderLoader>();
        }

        [Test()]
        public void TestLoadingEmptyFile()
        {
            var path = fixture.Create<string>();
            fileReaderMock.Setup(mock => mock.ReadAll(It.IsAny<string>())).Returns("");

            var result = loader.Load(path);

            Assert.IsEmpty(result);
            fileReaderMock.Verify(mock => mock.ReadAll(path), Times.Once);
        }


        [Test()]
        public void TestloadingAFileWithOrders()
        {
            var path = fixture.Create<string>();
            var text = "{\"order-001\": {\"destination\" : \"YYZ\"},"+
                         "\"order-002\": {\"destination\" : \"YYZ\"}}";
            
            fileReaderMock.Setup(mock => mock.ReadAll(It.IsAny<string>()))
                .Returns(text);

            var result = loader.Load(path).ToList();

            Assert.AreEqual(2, result.Count);
            fileReaderMock.Verify(mock => mock.ReadAll(path), Times.Once);
        }
    }
}
