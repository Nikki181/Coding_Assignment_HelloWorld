namespace HelloWorldAPI.Tests.UnitTests
{
    using System.Configuration;
    using System.IO;
    using Controllers;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TodaysDataControllerUnitTests
    {
        private Mock<IDataService> dataServiceMock;
        private TodaysDataController todaysDataController;

        [TestFixtureSetUp]
        public void InitTestSuite()
        {

            this.dataServiceMock = new Mock<IDataService>();
            this.todaysDataController = new TodaysDataController(this.dataServiceMock.Object);
        }

        #region Get Tests
        //     Tests the controller's get method for success
        
        [Test]
        public void UnitTestTodaysDataControllerGetSuccess()
        {
        
            var expectedResult = GetSampleTodaysData();


            this.dataServiceMock.Setup(m => m.GetTodaysData()).Returns(expectedResult);
            
            var result = this.todaysDataController.Get();
            
            Assert.NotNull(result);
            Assert.AreEqual(result.Data, expectedResult.Data);
        }
        
        //     Tests the controller's get method for a SettingsPropertyNotFoundException
       
        [Test]
        [ExpectedException(ExpectedException = typeof(SettingsPropertyNotFoundException))]
        public void UnitTestTodaysDataControllerGetSettingsPropertyNotFoundException()
        {
            this.dataServiceMock.Setup(m => m.GetTodaysData()).Throws(new SettingsPropertyNotFoundException("Error!"));
            
            this.todaysDataController.Get();
        }
        
       //     Tests the controller's get method for an IOException
       
        [Test]
        [ExpectedException(ExpectedException = typeof(IOException))]
        public void UnitTestTodaysDataControllerGetIOException()
        {
            this.dataServiceMock.Setup(m => m.GetTodaysData()).Throws(new IOException("Error!"));
this.todaysDataController.Get();
        }
        #endregion

        #region Helper Methods
       
        private static TodaysData GetSampleTodaysData()
        {
            return new TodaysData()
            {
                Data = "Hello World!"
            };
        }
        #endregion
    }
}