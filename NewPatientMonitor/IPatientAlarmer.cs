using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IPatientAlarmer
    {
        List<IAlarmTester> AlarmTesters { get; set; }
        void ReadingTest();
    }
}