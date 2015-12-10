using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewPatientMonitor;
using System.Collections.Generic;

namespace NewPatientMonitorTest
{
    [TestClass()]
    public class TestPatientDataWriter
    {
        [TestMethod()]
        public void TestWriterConstructor()
        {
            PatientDataWriter testDataWriter = new PatientDataWriter();
            Assert.IsNotNull(testDataWriter);
        }

        [TestMethod()]
        public void TestWriteData()
        {
            Mock<IPatientAlarmer> testAlarmer = new Mock<IPatientAlarmer>();
            testAlarmer.Setup(a => a.AlarmTesters).Returns(new List<IAlarmTester>());
            PatientDataWriter testDataWriter = new PatientDataWriter();
            testDataWriter.WriteData(testAlarmer.Object);
            Assert.Fail();
        }

        [TestMethod()]
        public void TestBedSet()
        {
            int testBedNumber = 1;
            PatientDataWriter testDataWriter = new PatientDataWriter();
            testDataWriter.BedNumber = testBedNumber;
            Assert.AreEqual(testBedNumber, testDataWriter.BedNumber);
        }

        [TestMethod()]
        public void TestAlarmSet()
        {
            Mock<IPatientAlarmer> testPatientAlarm = new Mock<IPatientAlarmer>();

            PatientDataWriter testDataWriter = new PatientDataWriter();
            testDataWriter.AlarmToBeStored = testPatientAlarm.Object;
            Assert.AreEqual(testPatientAlarm.Object, testDataWriter.AlarmToBeStored);
        }
    }
}