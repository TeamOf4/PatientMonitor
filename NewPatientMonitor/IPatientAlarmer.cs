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