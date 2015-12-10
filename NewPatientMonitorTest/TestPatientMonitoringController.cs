using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass()]
    public class TestPatientMonitoringController
    {
        [TestMethod()]
        public void TestPatientMonitoringControllerConstructor()
        {
            Mock<IPatientFactory> testFactory = new Mock<IPatientFactory>();
            Mock<IPatientData> testPatient = new Mock<IPatientData>();
            testPatient.Setup(a => a.Values).Returns(() => new List<float> {12f, 13f, 14f, 15f});
             
            
            testFactory.Setup(a => a.CreateAndReturnObj(PatientClassesEnumeration.PatientData)).Returns(testPatient);

            Assert.Fail();
        }
    }
}