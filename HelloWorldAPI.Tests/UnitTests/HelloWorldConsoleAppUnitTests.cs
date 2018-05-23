namespace HelloWorldAPI.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using ConsoleApp.Application;
    using ConsoleApp.Services;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HelloWorldConsoleAppUnitTests
    {
        private List<string> logMessageList;
        private List<Exception> exceptionList;
        private List<object> otherPropertiesList;
        private Mock<IHelloWorldWebService> helloWorldWebServiceMock;
        private ILogger testLogger;
        private HelloWorldConsoleApp helloWorldConsoleApp;
        [TestFixtureSetUp]
        public void InitTestSuite()
        {
            this.logMessageList = new List<string>();
            this.exceptionList = new List<Exception>();
            this.otherPropertiesList = new List<object>();

            this.helloWorldWebServiceMock = new Mock<IHelloWorldWebService>();
            this.testLogger = new TestLogger(ref this.logMessageList, ref this.exceptionList, ref this.otherPropertiesList);
            this.helloWorldConsoleApp = new HelloWorldConsoleApp(this.helloWorldWebServiceMock.Object, this.testLogger);
        }

        [TearDown]
        public void TearDown()
        {

            this.logMessageList.Clear();
            this.exceptionList.Clear();
            this.otherPropertiesList.Clear();
        }

        #region Run Tests
        [Test]
        public void UnitTestHelloWorldConsoleAppRunNormalDataSuccess()
        {
            const string Data = "Hello World!";
            var todaysData = GetSampleTodaysData(Data);
            this.helloWorldWebServiceMock.Setup(m => m.GetTodaysData()).Returns(todaysData);
            this.helloWorldConsoleApp.Run(null);
            Assert.AreEqual(this.logMessageList.Count, 1);
            Assert.AreEqual(this.logMessageList[0], Data);
        }
        [Test]
        public void UnitTestHelloWorldConsoleAppRunNullDataSuccess()
        {
            this.helloWorldWebServiceMock.Setup(m => m.GetTodaysData()).Returns((TodaysData)null);
            this.helloWorldConsoleApp.Run(null);
            Assert.AreEqual(this.logMessageList.Count, 1);
            Assert.AreEqual(this.logMessageList[0], "No data was found!");
        }
        #endregion

        #region Helper Methods
        /// <summary>
        ///     Gets a sample TodaysData model
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>A sample TodaysData model</returns>
        private static TodaysData GetSampleTodaysData(string data)
        {
            return new TodaysData { Data = data };
        }
        #endregion
    }
}