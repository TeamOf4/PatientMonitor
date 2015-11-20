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
    public class PatientAlarmer
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
        public List<AlarmTester> AlarmTesters
        {
            get;
            set;

        } = new List<AlarmTester>(4);

        
        //readonly AlarmTester breathingTester = new AlarmTester();
        //readonly AlarmTester diastolicTester = new AlarmTester("Diastolic Rate", DefaultSettings.LOWER_DIASTOLIC_RATE, DefaultSettings.UPPER_DIASTOLIC_RATE);
        //readonly AlarmTester pulseTester = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        //readonly AlarmTester systolicTester = new AlarmTester("Systolic Rate", DefaultSettings.LOWER_SYSTOLIC_RATE, DefaultSettings.UPPER_SYSTOLIC_RATE);
        //readonly AlarmTester temperatureTester = new AlarmTester("Temperature Rate", DefaultSettings.LOWER_TEMPERATURE_RATE, DefaultSettings.UPPER_TEMPERATURE_RATE);
        
        //public PatientAlarmer = new
        //public AlarmTester { get { return breathingTester; } }
        //public AlarmTester DiastolicRateTester { get { return diastolicTester; } }
        //public AlarmTester PulseRateTester { get { return pulseTester; } }
        //public AlarmTester SystolicRateTester { get { return systolicTester; } }
        //public AlarmTester TemperatureRateTester { get { return temperatureTester; } }
       
        public void ReadingTest(IPatientData reading)
        {
            for (int i = 0; i < 4; i++)
            {
                if (AlarmTesters[i].ValueOutsideLimits(reading.values[i]))
                {
                   
                }
            }

            //if (breathingTester.ValueOutsideLimits (reading.BreathingRate))
            //{
            //    if (BreathingRateAlarm != null) BreathingRateAlarm(this, null); 
            //}
            //if (diastolicTester.ValueOutsideLimits (reading.DiastolicRate))
            //{
            //    if (DiastolicRateAlarm != null) DiastolicRateAlarm(this, null);
            //}
            //if (pulseTester.ValueOutsideLimits (reading.PulseRate))
            //{
            //    if (PulseRateAlarm != null) PulseRateAlarm(this, null);
            //}
            //if (systolicTester.ValueOutsideLimits (reading.SystolicRate))
            //{
            //    if (SystolicRateAlarm != null) SystolicRateAlarm(this, null);
            //}
            //if (temperatureTester.ValueOutsideLimits (reading.TemperatureRate))
            //{
            //    if (TemperaturerateAlarm != null) TemperaturerateAlarm(this, null);
            //}
        }

    }
}
