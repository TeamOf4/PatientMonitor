/*
* Stores a list of alarm testers
* Contains an event handler event for the module
* Reads patient data, if the reading value is outside the limits (determined by alarm tester)
* then Module alarm is set to null J.S 
*/
using System;
using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IPatientAlarmer
    {
        List<IAlarmTester> AlarmTesters { get; }

        event EventHandler ModuleAlarm;

        void ReadingTest(IPatientData reading, IBedsideMonitor monitor);
    }
}