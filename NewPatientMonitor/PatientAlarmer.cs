﻿/*
* Stores a list of alarm testers
* Contains an event handler event for the module
* Reads patient data, if the reading value is outside the limits (determined by alarm tester)
* then Module alarm is set to null J.S 
*/

using System;
using System.Collections.Generic;

namespace NewPatientMonitor
{
    public sealed class PatientAlarmer : IPatientAlarmer
    {
        public event EventHandler ModuleAlarm;

        private List<IAlarmTester> _AlarmTesters => new List<IAlarmTester>();

        public List<IAlarmTester> AlarmTesters => _AlarmTesters;

        private void OnModuleAlarm() => ModuleAlarm?.Invoke(this, EventArgs.Empty);


        public void ReadingTest(IPatientData reading, IBedsideMonitor monitor)
        {
            SetLimits(monitor);

            for (int i = 0; i < AlarmTesters.Count; i++)
                if (_AlarmTesters[i].ValueOutsideLimits(reading.Values[i]))
                {
                    ModuleAlarm?.Invoke(this, null);
                }
        }

        private void SetLimits(IBedsideMonitor monitor)
        {
            foreach (IModule t in monitor.BedsideModules)
            {
                _AlarmTesters.Add(new AlarmTester(t));
            }
        }

    }
}