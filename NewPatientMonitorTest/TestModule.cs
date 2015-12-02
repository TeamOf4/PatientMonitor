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

            Assert.AreEqual(testModule.Name, DefaultSettings.NewModuleName);
            Assert.AreEqual(testModule.LowerLimit, DefaultSettings.LowerDefaultValue);
            Assert.AreEqual(testModule.UpperLimit, DefaultSettings.UpperDefaultValue);

            // This is a test comment.

            // Hello Nick
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
