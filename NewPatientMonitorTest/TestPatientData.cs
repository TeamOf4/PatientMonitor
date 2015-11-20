using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestPatientData
    {
        const string firstLine = "70,35,98,65,36.5";
        const string secondLine = "54,43,76,86,32";

        [TestMethod]
        public void dataCreatedCorrectly()
        {
            var patientData1 = new PatientData(firstLine);
            patientDataTestPass1(patientData1);
            var patientData2 = new PatientData(secondLine);
            patientdataTestPass2(patientData2);
        }

        [TestMethod]
        public void dataSetCorrectly()
        {
            var patientData = new PatientData();
            patientData.SetPatientData(firstLine);
            patientDataTestPass1(patientData);

            var patientData2 = new PatientData();
            patientData2.SetPatientData(secondLine);
            patientdataTestPass2(patientData2);
        }

        void patientDataTestPass1 (PatientData pd)
        {
            Assert.AreEqual(70f, pd.values[0]);
            Assert.AreEqual(35f, pd.values[1]);
            Assert.AreEqual(98f, pd.values[2]);
            Assert.AreEqual(65f, pd.values[3]);
        }

        void patientdataTestPass2 (PatientData pd)
        {
            Assert.AreEqual(54f, pd.values[0]);
            Assert.AreEqual(43f, pd.values[1]);
            Assert.AreEqual(76f, pd.values[2]);
            Assert.AreEqual(86f, pd.values[3]);
        }
    }
}
