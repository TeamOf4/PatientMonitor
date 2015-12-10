using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewPatientMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitorTest
{
    [TestClass()]
    public class TestPatientFactory
    {
        [TestMethod()]
        public void TestCreateAndReturnObjAlarmer()
        {
            PatientClassesEnumeration testClassesEnumeration = PatientClassesEnumeration.PatientAlarmer;
            IPatientFactory testFactory = new PatientFactory();
            testFactory.CreateAndReturnObj(testClassesEnumeration);
            Assert.IsNotNull(testFactory);
        }

        [TestMethod()]
        public void TestCreateAndReturnObjDataWriter()
        {
            PatientClassesEnumeration testClassesEnumeration = PatientClassesEnumeration.PatientDataWriter;
            IPatientFactory testFactory = new PatientFactory();
            testFactory.CreateAndReturnObj(testClassesEnumeration);
            Assert.IsNotNull(testFactory);
        }

        [TestMethod()]
        public void TestCreateAndReturnObjDataReader()
        {
            PatientClassesEnumeration testClassesEnumeration = PatientClassesEnumeration.PatientDataReader;
            IPatientFactory testFactory = new PatientFactory();
            testFactory.CreateAndReturnObj(testClassesEnumeration);
            Assert.IsNotNull(testFactory);
        }

        [TestMethod()]
        public void TestCreateAndReturnObjData()
        {
            PatientClassesEnumeration testClassesEnumeration = PatientClassesEnumeration.PatientData;
            IPatientFactory testFactory = new PatientFactory();
            testFactory.CreateAndReturnObj(testClassesEnumeration);
            Assert.IsNotNull(testFactory);
        }
    }
}