using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor;
using Moq;

namespace NewPatientMonitorTest
{
    [TestClass]
    public class TestAlarmTester
    {

        /*
        Brief Testing done to the Alarm tester class

        1) Creation of the alarm is good (Tests whether the alarm created matches the one setup [TestInitialize] 
        2) Whether the alarm is within limits
        3) Whether the alarm is outside the limits
        4) Test if the value setup is not zero
        5) Test if the value setup in not less (minus values)
            */

        // ARRANGE
        AlarmTester _alarmTesterCreated;

        // ACT
        [TestInitialize]
        public void Setup()
        {
            var moduleToAdd = new Mock<IModule>(MockBehavior.Strict);

            moduleToAdd.Setup(a => a.LowerLimit).Returns(12f);
            moduleToAdd.Setup(b => b.Name).Returns("Test");
            moduleToAdd.Setup(c => c.UpperLimit).Returns(54f);

            _alarmTesterCreated = new AlarmTester(moduleToAdd.Object);
        }
        // ASSERT
       
        [TestMethod]
        public void IsAlarmTestGoodCreation()
        {
            /* This test method test whether the created alarm is the same as the one setup for the test initialize above.
             If the elements below this comment is the same as the one created the test will pass, else the test will fail. (NW)*/
            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(10f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(20f);
            _alarmTesterCreated = new AlarmTester(testModule.Object);

            Assert.AreEqual(testModule.Object.Name, _alarmTesterCreated.NameOfAlarm);
            Assert.AreEqual(testModule.Object.LowerLimit, _alarmTesterCreated.LowerLimit);
            Assert.AreEqual(testModule.Object.UpperLimit, _alarmTesterCreated.UpperLimit);
        }

        [TestMethod]
        public void IsAlarmWithinLimits()
        {
            /* This test method will test whether the alarm values are in between the values 12f and 54f. 
             If the values fall in between 12 and 54 the test should pass. (NW) */

            Assert.IsFalse(_alarmTesterCreated.ValueOutsideLimits (13f));
            Assert.IsFalse(_alarmTesterCreated.ValueOutsideLimits (53f));
            Assert.IsFalse(_alarmTesterCreated.ValueOutsideLimits(41f));
        
        }

        [TestMethod]
        public void IsAlarmOutsideLimits()
        {
            /* This test method will test whether the values are outside the setup values 12f and 54f.
               If they are outside the test should pass. If in between should fail. (NW) */

            Assert.IsTrue(_alarmTesterCreated.ValueOutsideLimits(11f));
            Assert.IsTrue(_alarmTesterCreated.ValueOutsideLimits(9f));
            Assert.IsTrue(_alarmTesterCreated.ValueOutsideLimits(65f));
        }

        [TestMethod]
        public void  AlarmDetectsNotZero() 
        {
            // This test should pass since the values setup is above 0. (NW)
            

            Assert.IsTrue(_alarmTesterCreated.ValueOutsideLimits(0f));
        }
        [TestMethod]
        public void AlarmDoesNotDetectMinusValues()
        {

            // This test should pass if the values detected in the setup is not equal to -2f (NW)
            Assert.IsTrue(_alarmTesterCreated.ValueOutsideLimits(-2f));
        }




    }
}
