using System;
using System.Collections.Generic;

namespace NewPatientMonitor
{
    public sealed class PatientAlarmer : IPatientAlarmer
    {
        //public PatientAlarmer(List<IAlarmTester> alarmTesters)
        //{
        //    _AlarmTesters = alarmTesters;
        //}

        public event EventHandler ModuleAlarm;

        private List<IAlarmTester> _AlarmTesters => new List<IAlarmTester>();

        public List<IAlarmTester> AlarmTesters
        {
            get { return _AlarmTesters; }
        }

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