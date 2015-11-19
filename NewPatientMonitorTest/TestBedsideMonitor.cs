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
        public void TestAddingModuleToBedsideMonitor()
        {
             //arrange
            BedsideMonitor bedsidemonitor = new BedsideMonitor();
            var moduleToAdd = new Mock<IModule>(MockBehavior.Strict);

            moduleToAdd.Setup(a => a.LowerLimit).Returns(10f);
            moduleToAdd.Setup(b => b.Name).Returns("Test");
            moduleToAdd.Setup(c => c.UpperLimit).Returns(20f);

             //act
            bedsidemonitor.AddMonitor(moduleToAdd.Object);

            //assert

           Assert.IsTrue(bedsidemonitor.Bedsidemodules.Contains(moduleToAdd.Object));
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
        public void RemovingModule()
        {
            //arrange
            BedsideMonitor bedsidemonitor = new BedsideMonitor();
            var moduleToRemove = new Mock<IModule>(MockBehavior.Strict);

            moduleToRemove.Setup(a => a.LowerLimit).Returns(10f);
            moduleToRemove.Setup(b => b.Name).Returns("Test");
            moduleToRemove.Setup(c => c.UpperLimit).Returns(20f);

            //act
            bedsidemonitor.AddMonitor(moduleToRemove.Object);
            bedsidemonitor.RemoveMonitor(0);

            //assert

            Assert.IsFalse(bedsidemonitor.Bedsidemodules.Contains(moduleToRemove.Object));

        }
    }
}
