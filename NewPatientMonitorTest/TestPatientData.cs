using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestPatientData
    {
        const string FirstLine = "70,35,98,65,36.5";
        const string SecondLine = "54,43,76,86,32";

        [TestMethod]
        public void DataCreatedCorrectly()
        {
            var patientData1 = new PatientData(FirstLine);
            PatientDataTestPass1(patientData1);
            var patientData2 = new PatientData(SecondLine);
            PatientdataTestPass2(patientData2);
        }

        [TestMethod]
        public void DataSetCorrectly()
        {
            var patientData = new PatientData();
            patientData.SetPatientData(FirstLine);
            PatientDataTestPass1(patientData);

            var patientData2 = new PatientData();
            patientData2.SetPatientData(SecondLine);
            PatientdataTestPass2(patientData2);
        }

        void PatientDataTestPass1 (PatientData pd)
        {
            Assert.AreEqual(70f, pd.Values[0]);
            Assert.AreEqual(35f, pd.Values[1]);
            Assert.AreEqual(98f, pd.Values[2]);
            Assert.AreEqual(65f, pd.Values[3]);
        }

        void PatientdataTestPass2 (PatientData pd)
        {
            Assert.AreEqual(54f, pd.Values[0]);
            Assert.AreEqual(43f, pd.Values[1]);
            Assert.AreEqual(76f, pd.Values[2]);
            Assert.AreEqual(86f, pd.Values[3]);
        }
    }
}
