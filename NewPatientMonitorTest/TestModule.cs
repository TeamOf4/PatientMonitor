using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

/*
 *  Unit tests for the module class J.S
*/ 

namespace NewPatientMonitorTest
{
    // Asserts that the module has been created with default settings J.S
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

        // Asserts that the module has been created with the set name J.S
        [TestMethod]
        public void ModuleCreatedWithSetName()
        {
            string testName = "This is a test name";
            Module testModule = new Module(testName);

            Assert.AreEqual(testModule.Name, testName);
        }

        // Assert that the module has been created with the set name and values J.S
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
