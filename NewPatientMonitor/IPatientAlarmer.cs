using System;
using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IPatientAlarmer
    {
        List<IAlarmTester> AlarmTesters { get; }
        List<EventHandler> ModuleAlarms { get; set; }

        void ReadingTest(IPatientData reading, IBedsideMonitor monitor);
    }
}