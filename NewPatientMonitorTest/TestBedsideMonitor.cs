using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;
using Moq; // Installed the Moq testing from nuget packages

namespace NewPatientMonitorTest
{
    /// <summary>
    /// Summary description for TestBedsideMonitor
    /// </summary>
    [TestClass]
    public class TestBedsideMonitor
    {
        [TestMethod]
        public void TestAddingModule()
        {
             //arrange
            BedsideMonitor bedsidemonitor = new BedsideMonitor();
            var moduleToAdd = new Mock<IModule>().Object;
             //act
            bedsidemonitor.AddMonitor(moduleToAdd);
             //assert
            Assert.;

            //Assert.AreEqual(testModule.Name, testName);
            //Assert.AreEqual(testModule.UpperLimit, upperLimit);
            //Assert.AreEqual(testModule.LowerLimit, lowerLimit);
        }
        #region Additional test attributes
       // //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {

          //test to ensure that the modules work 

        }
    }
}
