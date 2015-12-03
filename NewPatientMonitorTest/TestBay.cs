using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass()]
    public class TestBay
    {
        [TestMethod()]
        public void TestAddBedSideMonitor()
        {
            IBay testBay = new Bay();
            testBay.AddBedSideMonitor();

            Assert.IsNotNull(testBay.Beds[0]);
        }

        [TestMethod()]
        public void TestRemoveBedsideMonitor()
        {
            IBay testBay = new Bay();
            testBay.AddBedSideMonitor();
            testBay.RemoveBedsideMonitor(0);

            Assert.AreEqual(DefaultSettings.NumberOfBeds - 1, testBay.Beds.Count);
        }
    }
}