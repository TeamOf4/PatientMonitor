using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

/*
 *  Unit tests for the module class
*/ 

namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestModule
    {
        [TestMethod]
        public void ModuleCreatedWithDefaultSettings()
        {
            Module testModule = new Module();

            bool test = testModule.Name == DefaultSettings.DefaultNewModule.Name && testModule.LowerLimit == DefaultSettings.DefaultNewModule.LowerLimit || testModule.UpperLimit == DefaultSettings.DefaultNewModule.UpperLimit;

            Assert.IsTrue(test);
        }

        [TestMethod]
        public void ModuleCreatedWithSetName()
        {
            string testName = "This is a test name";
            Module testModule = new Module(testName);

            Assert.AreEqual(testModule.Name, testName);
        }

        [TestMethod]
        public void ModuleCreatedWithSetNameAndValues()
        {
            string testName = "This is another test name";
            float upperLimit = 20f;
            float lowerLimit = 2f;

            Module testModule = new Module(testName, lowerLimit, upperLimit);

            Assert.AreEqual(testModule.Name, testName);
            Assert.AreEqual(testModule.UpperLimit, upperLimit);
            Assert.AreEqual(testModule.LowerLimit, lowerLimit);
        }
    }
}
