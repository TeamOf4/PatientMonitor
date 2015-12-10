using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass()]
    public class TestBay
    {
        // Checks that a new bedside monitor ha sbeen added to the empty bay J.S
        [TestMethod()]
        public void TestAddBedSideMonitor()
        {
            IBay testBay = new Bay();
            testBay.AddBedSideMonitor();

            Assert.IsNotNull(testBay.BedsideMonitors[0]);
        }

        //  Checks that the selected bay is removed from the monitor J.S
        [TestMethod()]
        public void TestRemoveBedsideMonitor()
        {
            IBay testBay = new Bay(2);
            testBay.RemoveBedsideMonitor(0);

            Assert.AreEqual(1, testBay.BedsideMonitors.Count);

        }

        // Tests that the created list of bays is the same as the returned list of bays J.S
        [TestMethod()]
        public void GetListOfBedsideMonitorsTest()
        {
            IBay testBay = new Bay();
            testBay.AddBedSideMonitor();
            IBay listOfBaysFromTestBay = new Bay();
            listOfBaysFromTestBay.BedsideMonitors = testBay.GetListOfBedsideMonitors();

            Assert.AreEqual(testBay.BedsideMonitors,listOfBaysFromTestBay.BedsideMonitors);
        }
    }
}