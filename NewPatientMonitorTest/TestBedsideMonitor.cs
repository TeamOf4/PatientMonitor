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
            bedsidemonitor.AddModule(moduleToAdd.Object);

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
            bedsidemonitor.AddModule(moduleToRemove.Object);
            bedsidemonitor.RemoveModule(0);

            //assert

            Assert.IsFalse(bedsidemonitor.Bedsidemodules.Contains(moduleToRemove.Object));

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

            Assert.AreEqual(testModuleNew.Object,testBedsideMonitor.Bedsidemodules[1]);
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

            Assert.AreEqual(testModule.Object, testBedsideMonitor.Bedsidemodules[0]);
        }
    }
}
