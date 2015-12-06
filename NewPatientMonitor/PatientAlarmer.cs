using System;
using System.Collections.Generic;

namespace NewPatientMonitor
{
    public class PatientAlarmer : IPatientAlarmer
    {
        public PatientAlarmer(List<IAlarmTester> alarmTesters)
        {
            _AlarmTesters = alarmTesters;
        }

        public event EventHandler ModuleAlarm;

        private List<IAlarmTester> _AlarmTesters { get; } = new List<IAlarmTester>();

        public List<IAlarmTester> AlarmTesters => _AlarmTesters;


        public PatientAlarmer()
        {
            
        }

        public void ReadingTest(IPatientData reading, IBedsideMonitor monitor)
        {
            SetLimits(monitor);

            for (int i = 0; i < AlarmTesters.Count; i++)
                if (AlarmTesters[i].ValueOutsideLimits(reading.Values[i]))
                    if (ModuleAlarm != null) ModuleAlarm(this, null);                   
        }

        private void SetLimits(IBedsideMonitor monitor)
        {
            foreach (IModule t in monitor.BedsideModules)
            {
                _AlarmTesters.Add(new AlarmTester(t));
            }
        }

        protected virtual void OnModuleAlarm()
        {
            ModuleAlarm?.Invoke(this, EventArgs.Empty);
        }
    }
}