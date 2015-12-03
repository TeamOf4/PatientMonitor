using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Media;

/*
HELP
*/

namespace NewPatientMonitor
{
    public class PatientAlarmer : IPatientAlarmer
    {
        /*
        The code below tells the compiler where to get the values from. In this case it obtains
        the values within the default settings. 
        
        I have specified in this sequence:

        Module Name , Lower Breathing Rate (Default Settings), Upper Breathing Rate (Default Settings)
        */

        public List<IAlarmTester> AlarmTesters { get; set; } = new List<IAlarmTester>(4);

        public void ReadingTest()
        {
            throw new NotImplementedException();
        }

        public event EventHandler Module1Alarm;
        public event EventHandler Module2Alarm;
        public event EventHandler Module3Alarm;
        public event EventHandler Module4Alarm;

        private IBedsideMonitor BedsideMonitorToTest
        {
            get;
            set;
        }

        public void GetBedsideMonitor(IBedsideMonitor bedsideMonitorToTest)
        {
            BedsideMonitorToTest = bedsideMonitorToTest;
        }

        public bool ReadingTest(IPatientData reading, int bedNumber)
        {
            var tempBed = new Bay();

            for (var i = 0; i < 4; i++)
            {
                AlarmTesters.Add(new AlarmTester(tempBed.Beds[bedNumber].Bedsidemodules[i]));

                if (!AlarmTesters[i].ValueOutsideLimits(reading.Values[i]))
                    return true;
            }

            return false;
        }
    }
}