using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;

namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestAlarmTester
    {
        // ARRANGE
        AlarmTester alarmTesterCreated;

        // ACT
        [TestInitialize]
        public void setup()
        {
             alarmTesterCreated = new AlarmTester("Module Name", 12f, 54f);
             // alarmTesterCreated = new AlarmTester("Module Name", 0f, 0f);
        }

        // ASSERT
       
        [TestMethod]
        public void IsAlarmTestGoodCreation()
        {
            // This test method test whether the created alarm is the same as the one setup for the test initialize above.
            // If the elements below this comment is the same as the one created the test will pass, else the test will fail.

            Assert.AreEqual("Module Name", alarmTesterCreated.NameOfAlarm);
            Assert.AreEqual(12f, alarmTesterCreated.LowerLimit);
            Assert.AreEqual(54f, alarmTesterCreated.UpperLimit);
        }

        [TestMethod]
        public void IsAlarmWithinLimits()
        {
            // This test method will test whether the alarm values are in between the values 12f and 54f. 
            // If the values fall in between 12 and 54 the test should pass.

            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits (13f));
            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits (53f));
            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits(41f));
        
        }

        [TestMethod]
        public void IsAlarmOutsideLimits()
        {
            // This test method will test whether the values are outside the setup values 12f and 54f.
            // If they are outside the test should pass. If in between should fail.

            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(11f));
            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(9f));
            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(65f));
        }

        [TestMethod]
        public void  AlarmDropsToZero() 
        {
            // Do we need to check whether the values drop to zero.

            // This test should fail by default, since the values are greater than 0 (Both 12f and 54f are > 0)

            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits (0f));
            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits(0f));
            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits(0f));

            /*Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(0f));
            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(0f));
            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(0f));*/
        }

        
    }
}
