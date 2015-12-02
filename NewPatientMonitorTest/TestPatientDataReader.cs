using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestPatientDataReader
    {
        const string FirstLine = "45,24,110,65,32.5";
        const string SecondLine = "98,54,108,43,32";

        [TestMethod]
        public void HasGoodCreation ()
        {

            // Checks to see whether there is a file named DataTest within the same directory as NewPatientMonitor. (NW)
            var dataReader = new PatientDataReader(@"..\..\..\DataTest.csv");
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void BadNamedFile ()
        {
            // Checks to see if there is a badly named file called NoneExistant.csv file. (NW)
            new PatientDataReader(@"..\..\..\NoneExistant.csv");
        }

        [TestMethod]
        public void GoodUnconnectedCreation()
        {
            var dataReader = new PatientDataReader();
            dataReader.Connect(@"..\..\..\DataTest.csv");
            Assert.AreEqual(FirstLine, dataReader.GetData());
            Assert.AreEqual(SecondLine, dataReader.GetData());
        }
    }
}
