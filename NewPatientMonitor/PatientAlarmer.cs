using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
HELP
*/
namespace NewPatientMonitor
{
    public class PatientAlarmer : IPatientAlarmer
    {
        
        public event EventHandler Module1Alarm;
        public event EventHandler Module2Alarm;
        public event EventHandler Module3Alarm;
        public event EventHandler Module4Alarm;

        /*
        The code below tells the compiler where to get the values from. In this case it obtains
        the values within the default settings. 
        
        I have specified in this sequence:

        Module Name , Lower Breathing Rate (Default Settings), Upper Breathing Rate (Default Settings)
        */
        public List<IAlarmTester> AlarmTesters
        {
            get;
            set;

        } = new List<IAlarmTester>(4);
       
        public void ReadingTest(IPatientData reading, int bedNumber)
        {
            bed tempBed = new bed();

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    AlarmTesters.Add(new AlarmTester(tempBed.beds[bedNumber].Bedsidemodules[i]));
                    if (AlarmTesters[i].ValueOutsideLimits(reading.values[i]))
                    {
                        // soundAlarm();
                        throw new NotImplementedException();


                    }
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
            }
            
            }
        

        void soundAlarm()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\PatientMonitor\NewPatientMonitor\bin\Debug\Resources\Mutable.wav");
            player.Play();
        }

        public void readingTest()
        {
            throw new NotImplementedException();
        }
    }
}
