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
        (NW)
        */

        // ASSERT

       [TestMethod]
        public void IsAlarmNameSetToModuleName()
        {
            /* This test method test whether the created alarm is the same as the one setup for the test initialize above.
               If the elements below this comment is the same as the one created the test will pass, else the test will fail. (NW)*/

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated = new AlarmTester(testModule.Object);

            Assert.AreEqual(testModule.Object.Name, alarmTesterCreated.NameOfAlarm); 
        }

        [TestMethod]
        public void IsAlarmUpperLimitSetToModuleUpperLimit()
        {
            /* This test method test whether the created alarm is the same as the one setup for the test initialize above.
               If the elements below this comment is the same as the one created the test will pass, else the test will fail. (NW)*/

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(10f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated= new AlarmTester(testModule.Object);

            Assert.AreEqual(testModule.Object.UpperLimit, alarmTesterCreated.UpperLimit);
        }

        [TestMethod]
        public void IsAlarmLowerLimitSetToModuleLowerLimit()
        {
            /* This test method test whether the created alarm is the same as the one setup for the test initialize above.
               If the elements below this comment is the same as the one created the test will pass, else the test will fail. (NW)*/

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated = new AlarmTester(testModule.Object);

            Assert.AreEqual(testModule.Object.LowerLimit, alarmTesterCreated.LowerLimit);
        }

        [TestMethod]
        public void AlarmIsWithinLimits()
        {
            /* This test method will test whether the alarm values are in between the values 12f and 54f. 
               If the values fall in between 12 and 54 the test should pass. (NW) */

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated = new AlarmTester(testModule.Object);
            Assert.IsFalse(alarmTesterCreated.ValueOutsideLimits (13f));        
        }

        [TestMethod]
        public void IsAlarmOutsideLimits()
        {
            /* This test method will test whether the values are outside the setup values 12f and 54f.
               If they are outside the test should pass. If in between should fail. (NW) */

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated = new AlarmTester(testModule.Object);
            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(11f));
        }

        [TestMethod]
        public void  IsAlarmGreaterThanZero() 
        {
            // This test should pass since the values setup is above 0. (NW)

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated = new AlarmTester(testModule.Object);

            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(0f));
        }
        [TestMethod]
        public void AlarmDoesNotDetectMinusValues()
        {

            // This test should pass if the values detected in the setup is not equal to -2f (NW)

            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester alarmTesterCreated = new AlarmTester(testModule.Object);

            Assert.IsTrue(alarmTesterCreated.ValueOutsideLimits(-2f));
        }

        [TestMethod]
        public void GetAlarmTesterName()
        {
            var testModule = new Mock<IModule>(MockBehavior.Strict);

            testModule.Setup(a => a.LowerLimit).Returns(12f);
            testModule.Setup(b => b.Name).Returns("Test");
            testModule.Setup(c => c.UpperLimit).Returns(54f);

            IAlarmTester testAlarmTester = new AlarmTester(testModule.Object);

            string alarmName = testAlarmTester.NameOfAlarm;

            Assert.AreEqual(testModule.Object.Name, testAlarmTester.NameOfAlarm);
        }


    }
}
