using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass]
    public class PatientDataTest
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
            Assert.AreEqual(70f, pd.PulseRate);
            Assert.AreEqual(35f, pd.BreathingRate);
            Assert.AreEqual(98f, pd.SystolicRate);
            Assert.AreEqual(65f, pd.DiastolicRate);
            Assert.AreEqual(36.5f, pd.TemperatureRate);
        }

        void patientdataTestPass2 (PatientData pd)
        {
            Assert.AreEqual(54f, pd.PulseRate);
            Assert.AreEqual(43f, pd.BreathingRate);
            Assert.AreEqual(76f, pd.SystolicRate);
            Assert.AreEqual(86f, pd.DiastolicRate);
            Assert.AreEqual(32f, pd.TemperatureRate);
        }
    }
}
