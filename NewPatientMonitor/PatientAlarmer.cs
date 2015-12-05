using System;
using System.Collections.Generic;

/*
HELP
*/

namespace NewPatientMonitor
{
    public class PatientAlarmer : IPatientAlarmer
    {
        public PatientAlarmer(List<IAlarmTester> alarmTesters)
        {
            this._AlarmTesters = alarmTesters;
        }

        /*
        The code below tells the compiler where to get the values from. In this case it obtains
        the values within the default settings. 
        
        I have specified in this sequence:

        Module Name , Lower Breathing Rate (Default Settings), Upper Breathing Rate (Default Settings)
        */


        //public event EventHandler Module1Alarm;
        //public event EventHandler Module2Alarm;
        //public event EventHandler Module3Alarm;
        //public event EventHandler Module4Alarm;

        public List<EventHandler> ModuleAlarms { get; set; } =
            new List<EventHandler>();

        private List<IAlarmTester> _AlarmTesters { get; set; } = new List<IAlarmTester>();

        public List<IAlarmTester> AlarmTesters => _AlarmTesters;


        //private IBedsideMonitor BedsideMonitorToTest
        //{
        //    get;
        //    set;
        //}

        public PatientAlarmer()
        {
            
        }

        //public void GetBedsideMonitor(IBedsideMonitor bedsideMonitorToTest)
        //{
        //    BedsideMonitorToTest = bedsideMonitorToTest;
        //}


        public void ReadingTest(IPatientData reading, IBedsideMonitor monitor)
        {
            SetLimits(monitor);

            for (int i = 0; i < AlarmTesters.Count; i++)
                if (AlarmTesters[i].ValueOutsideLimits(reading.Values[i]))
                    if (ModuleAlarms[i] != null) ModuleAlarms[i](this, null);                   
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