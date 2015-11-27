using System;
using Moq; // Installed the Moq testing from nuget packages
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPatientMonitor; //This Using line was added because it will use the NewPatientMonitor
using System.Collections.Generic;


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

            patientData.Setup(a => a.values).Returns(() => new List<float> { 13 /*, 13, 13, 13 */ });
            patientData.Setup(b => b.values).Returns(() => new List<float> { 74 /*, 74, 74, 74 */});
            patientData.Setup(c => c.values).Returns(() => new List<float> { 60 /*, 60, 60, 60 */});
            patientData.Setup(d => d.values).Returns(() => new List<float> { 125/*, 125, 125, 125 */});


            /*patientData.Setup(a => a.values[0]).Returns (13f);
            patientData.Setup(b => b.values[1]).Returns(74f);
            patientData.Setup(c => c.values[2]).Returns(60f);
            patientData.Setup(d => d.values[3]).Returns(125f);*/

            // The code above checks to see if no events are called (NW)

            var breathingRateAlarmWasCalled = false;
            var diastolicRateAlarmWasCalled = false;
            var pulseRateAlarmWasCalled = false;
            var systolicAlarmWasCalled = false;
            var temperatureRateAlarmWasCalled = false;
          
            patientAlarmer.Module1Alarm += (sender, e) => breathingRateAlarmWasCalled = true;
            patientAlarmer.Module2Alarm += (sender, e) => diastolicRateAlarmWasCalled = true;
            patientAlarmer.Module3Alarm += (sender, e) => pulseRateAlarmWasCalled = true;
            patientAlarmer.Module4Alarm += (sender, e) => systolicAlarmWasCalled = true;
            //patientAlarmer.TemperaturerateAlarm += (sender, e) => temperatureRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object, 0); 

            Assert.IsFalse(breathingRateAlarmWasCalled);
            Assert.IsFalse(diastolicRateAlarmWasCalled);
            Assert.IsFalse(pulseRateAlarmWasCalled);
            Assert.IsFalse(systolicAlarmWasCalled);
            Assert.IsFalse(temperatureRateAlarmWasCalled);

        }

        /* The test below checks to see whether the module drops below the set value. If it's within the limits it will fail (NW)*/

        [TestMethod]
        public void ValueWasCalled()
        {
            var patientData = new Mock<IPatientData>();

            patientData.Setup(a => a.values).Returns(() => new List<float> { 9f, 9f, 9f, 9f });

            var breathingRateAlarmWasCalled = false;
            patientAlarmer.Module1Alarm += (sender, e) => breathingRateAlarmWasCalled = true;
            patientAlarmer.ReadingTest(patientData.Object,0);
            Assert.IsTrue(breathingRateAlarmWasCalled);
        }
    }
}
