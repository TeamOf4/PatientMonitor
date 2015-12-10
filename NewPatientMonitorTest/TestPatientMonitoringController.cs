using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitorTest
{
    [TestClass()]
    public class TestPatientMonitoringController
    {
        [TestMethod()]
        public void TestRunMonitor()
        {
            MainWindow testWindow = null;
            Mock<IPatientFactory> testFactory = new Mock<IPatientFactory>();
            IPatientMonitoringController testController = new PatientMonitoringController(testWindow, testFactory.Object);
            Assert.Fail();
        }

        [TestMethod()]
        public void TestRunMonitor1()
        {
            Mock<MainWindow> testWindow = new Mock<MainWindow>();
            Mock<IPatientFactory> testFactory = new Mock<IPatientFactory>();
            IPatientMonitoringController testController = new PatientMonitoringController(testWindow.Object, testFactory.Object);
            testController.RunMonitor();
            Assert.Fail();
        }
    }
}