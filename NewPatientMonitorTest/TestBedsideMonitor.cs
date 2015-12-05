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
        public void TestGettingListOfModules()
        {
            BedsideMonitor testBedsideMonitor = new BedsideMonitor();

            var moduleToAdd = new Mock<IModule>(MockBehavior.Strict);

            moduleToAdd.Setup(a => a.LowerLimit).Returns(10f);
            moduleToAdd.Setup(b => b.Name).Returns("Test");
            moduleToAdd.Setup(c => c.UpperLimit).Returns(20f);

            testBedsideMonitor.AddModule(moduleToAdd.Object);

            List <IModule> testModuleList = testBedsideMonitor.GetListOfModules();

            CollectionAssert.Contains(testModuleList, moduleToAdd.Object);
        }
        [TestMethod]
        public void TestAddingModuleToBedsideMonitor()
        {
            //arrange
            BedsideMonitor testBedsideMonitor = new BedsideMonitor();
            var moduleToAdd = new Mock<IModule>(MockBehavior.Strict);

            moduleToAdd.Setup(a => a.LowerLimit).Returns(10f);
            moduleToAdd.Setup(b => b.Name).Returns("Test");
            moduleToAdd.Setup(c => c.UpperLimit).Returns(20f);

            //act
            testBedsideMonitor.AddModule(moduleToAdd.Object);
            List<IModule> testModuleList = testBedsideMonitor.GetListOfModules();

            //assert

            Assert.IsTrue(testModuleList.Contains(moduleToAdd.Object));
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
            BedsideMonitor testBedsideMonitor = new BedsideMonitor();
            var moduleToRemove = new Mock<IModule>(MockBehavior.Strict);

            moduleToRemove.Setup(a => a.LowerLimit).Returns(10f);
            moduleToRemove.Setup(b => b.Name).Returns("Test");
            moduleToRemove.Setup(c => c.UpperLimit).Returns(20f);

            //act
            testBedsideMonitor.ChangeModule(0, moduleToRemove.Object);
            testBedsideMonitor.RemoveModule(0);
            List<IModule> testModuleList = testBedsideMonitor.GetListOfModules();

            //assert

            Assert.IsFalse(testModuleList.Contains(moduleToRemove.Object));

        }

        [TestMethod()]
        public void TestChangeModule()
        {
            var testModuleOld = new Mock<IModule>();
            testModuleOld.Setup(a => a.Name).Returns("TestOld");
            testModuleOld.Setup(b => b.LowerLimit).Returns(10f);
            testModuleOld.Setup(c => c.UpperLimit).Returns(15f);

            var testModuleNew = new Mock<IModule>();
            testModuleNew.Setup(a => a.Name).Returns("TestOld");
            testModuleNew.Setup(b => b.LowerLimit).Returns(10f);
            testModuleNew.Setup(c => c.UpperLimit).Returns(15f);

            IBedsideMonitor testBedsideMonitor = new BedsideMonitor();
            testBedsideMonitor.AddModule(testModuleOld.Object);
            testBedsideMonitor.AddModule(testModuleOld.Object);
            testBedsideMonitor.ChangeModule(1, testModuleNew.Object);
            List<IModule> testModuleList = testBedsideMonitor.GetListOfModules();

            Assert.AreEqual(testModuleNew.Object, testModuleList[1]);
        }

        [TestMethod()]
        public void TestAddModule()
        {
            var testModule = new Mock<IModule>();
            testModule.Setup(a => a.Name).Returns("Test");
            testModule.Setup(b => b.LowerLimit).Returns(10f);
            testModule.Setup(c => c.UpperLimit).Returns(15f);

            IBedsideMonitor testBedsideMonitor = new BedsideMonitor();
            testBedsideMonitor.AddModule(testModule.Object);
            List<IModule> testModuleList = testBedsideMonitor.GetListOfModules();

            CollectionAssert.Contains(testModuleList, testModule.Object);
        }
    }
}
