using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewPatientMonitor;
// Installed the Moq testing from nuget packages
//This Using line was added because it will use the NewPatientMonitor


namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestPatientAlarmer
    {
        [TestMethod()]
        public void ReadingTestAlarmNotCalled()
        {
            var alarmCalled = false;

            var testModule = new Mock<IModule>();

            testModule.Setup(a => a.Name).Returns("Test Module");
            testModule.Setup(b => b.LowerLimit).Returns(5f);
            testModule.Setup(c => c.UpperLimit).Returns(10f);

            var testReadings = new Mock<IPatientData>();
            var values = new List<float>(4) {7f,6f,5f,4f};
            testReadings.Setup(a => a.Values).Returns(values);

            var testMonitor = new Mock<IBedsideMonitor>();
            testMonitor.Setup(a => a.BedsideModules).Returns(new List<IModule>(4) {new Module(testModule.Object), new Module(testModule.Object), new Module(testModule.Object), new Module(testModule.Object), });

            IPatientAlarmer testAlarmer = new PatientAlarmer();

            testAlarmer.ReadingTest(testReadings.Object,testMonitor.Object);
            testAlarmer.ModuleAlarm += (sender, e) => alarmCalled = true;

            Assert.IsFalse(alarmCalled);
        }

        [TestMethod()]
        public void ReadingTestAlarmWasCalled()
        {
            var alarmCalled = true;

            var testModule = new Mock<IModule>();

            testModule.Setup(a => a.Name).Returns("Test Module");
            testModule.Setup(b => b.LowerLimit).Returns(5f);
            testModule.Setup(c => c.UpperLimit).Returns(10f);

            var testReadings = new Mock<IPatientData>();
            var values = new List<float>(4) { 7f, 6f, 5f, 4f };
            testReadings.Setup(a => a.Values).Returns(values);

            var testMonitor = new Mock<IBedsideMonitor>();
            testMonitor.Setup(a => a.BedsideModules).Returns(new List<IModule>(4) { new Module(testModule.Object), new Module(testModule.Object), new Module(testModule.Object), new Module(testModule.Object), });

            IPatientAlarmer testAlarmer = new PatientAlarmer();

            testAlarmer.ReadingTest(testReadings.Object, testMonitor.Object);
            testAlarmer.ModuleAlarm += (sender, e) => alarmCalled = false;

            Assert.IsTrue(alarmCalled);
        }
    }
}
