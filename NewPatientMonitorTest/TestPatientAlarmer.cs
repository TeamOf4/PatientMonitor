using System;
using Moq; // Installed the Moq testing from nuget packages
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor; //This Using line was added because it will use the NewPatientMonitor


namespace TestMethodPMS
{
    [TestClass]
    public class TestPatientAlarmer
    {
        PatientAlarmer patientAlarmer;

        [TestInitialize]
        public void setup ()
        {
            patientAlarmer = new PatientAlarmer();
        }


        [TestMethod]
        public void IfNoEventsCalled()
        {
            // ARRANGE

            var patientData = new Mock<IPatientData>();
            // From the left we have our arguments, the result however is on the right.

            /*

            At the moment this test is testing whether any of the modules are called.
            It's searching through the values below to see whether its higher or lower than the default value
            If the values below are in between the test should pass
            If any of the values listed below is out of the defualt limit, it should fail
            (NW)
            */
            patientData.Setup(a => a.BreathingRate).Returns (13f);
            patientData.Setup(b => b.DiastolicRate).Returns(74f);
            patientData.Setup(c => c.PulseRate).Returns(60f);
            patientData.Setup(d => d.SystolicRate).Returns(125f);
            patientData.Setup(e => e.TemperatureRate).Returns(38f);

            // The code above checks to see if no events are called

            var breathingRateAlarmWasCalled = false;
            var diastolicRateAlarmWasCalled = false;
            var pulseRateAlarmWasCalled = false;
            var systolicAlarmWasCalled = false;
            var temperatureRateAlarmWasCalled = false;
          
            patientAlarmer.BreathingRateAlarm += (sender, e) => breathingRateAlarmWasCalled = true;
            patientAlarmer.DiastolicRateAlarm += (sender, e) => diastolicRateAlarmWasCalled = true;
            patientAlarmer.PulseRateAlarm += (sender, e) => pulseRateAlarmWasCalled = true;
            patientAlarmer.SystolicRateAlarm += (sender, e) => systolicAlarmWasCalled = true;
            patientAlarmer.TemperaturerateAlarm += (sender, e) => temperatureRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object); 
            // ASSERT

            Assert.IsFalse(breathingRateAlarmWasCalled);
            Assert.IsFalse(diastolicRateAlarmWasCalled);
            Assert.IsFalse(pulseRateAlarmWasCalled);
            Assert.IsFalse(systolicAlarmWasCalled);
            Assert.IsFalse(temperatureRateAlarmWasCalled);

        }

        /*

        The test created below test each of the individual modules. In the event that a module
        drops below the set value. The nurse will be notified. This test tests whether the modules drop below the 
        default values set in the default settings. For example BreathingRateWas Called monitors whether the value is above or below the set values.
        If the values are outside the set values the test for that particular test will pass. If however it's within the limits it will fail. 
        
        */

        [TestMethod]
        public void BreathingRateWasCalled()
        {
            var patientData = new Mock<IPatientData>();
            patientData.Setup(a => a.BreathingRate).Returns(9f);
            var breathingRateAlarmWasCalled = false;
            patientAlarmer.BreathingRateAlarm += (sender, e) => breathingRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object);
            Assert.IsTrue(breathingRateAlarmWasCalled);
        }

        [TestMethod]
        public void DiastolicPressureRateWasCalled()
        {
            var patientData = new Mock<IPatientData>();
            patientData.Setup(a => a.DiastolicRate).Returns(54f);
            var diastolicRateAlarmWasCalled = false;
            patientAlarmer.DiastolicRateAlarm += (sender, e) => diastolicRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object);
            Assert.IsTrue(diastolicRateAlarmWasCalled);
        }

        [TestMethod]
        public void PulseRateWasCalled()
        {
            var patientData = new Mock<IPatientData>();
            patientData.Setup(a => a.PulseRate).Returns(45f);
            var pulseRateAlarmWasCalled = false;
            patientAlarmer.PulseRateAlarm += (sender, e) => pulseRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object);
            Assert.IsTrue(pulseRateAlarmWasCalled);
        }

        [TestMethod]
        public void SystolicPressureRateWasCalled()
        {
            var patientData = new Mock<IPatientData>();
            patientData.Setup(a => a.SystolicRate).Returns(100f);
            var systolicRateAlarmWasCalled = false;
            patientAlarmer.SystolicRateAlarm += (sender, e) => systolicRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object);
            Assert.IsTrue(systolicRateAlarmWasCalled);
        }

        [TestMethod]
        public void TemperatureRateWasCalled()
        {
            var patientData = new Mock<IPatientData>();
            patientData.Setup(a => a.TemperatureRate).Returns(34f);
            var temperatureRateAlarmWasCalled = false;
            patientAlarmer.TemperaturerateAlarm += (sender, e) => temperatureRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object);
            Assert.IsTrue(temperatureRateAlarmWasCalled);
        }



    }
}
