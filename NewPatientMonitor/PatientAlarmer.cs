using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class PatientAlarmer
    {
        
        public event EventHandler BreathingRateAlarm;
        public event EventHandler DiastolicRateAlarm;
        public event EventHandler PulseRateAlarm;
        public event EventHandler SystolicRateAlarm;
        public event EventHandler TemperaturerateAlarm;

        /*
        The code below tells the compiler where to get the values from. In this case it obtains
        the values within the default settings. 
        
        I have specified in this sequence:

        Module Name , Lower Breathing Rate (Default Settings), Upper Breathing Rate (Default Settings)
        */

        readonly AlarmTester breathingTester = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester diastolicTester = new AlarmTester("Diastolic Rate", DefaultSettings.LOWER_DIASTOLIC_RATE, DefaultSettings.UPPER_DIASTOLIC_RATE);
        readonly AlarmTester pulseTester = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester systolicTester = new AlarmTester("Systolic Rate", DefaultSettings.LOWER_SYSTOLIC_RATE, DefaultSettings.UPPER_SYSTOLIC_RATE);
        readonly AlarmTester temperatureTester = new AlarmTester("Temperature Rate", DefaultSettings.LOWER_TEMPERATURE_RATE, DefaultSettings.UPPER_TEMPERATURE_RATE);
        
        public AlarmTester BreatingRateTester { get { return breathingTester; } }
        public AlarmTester DiastolicRateTester { get { return diastolicTester; } }
        public AlarmTester PulseRateTester { get { return pulseTester; } }
        public AlarmTester SystolicRateTester { get { return systolicTester; } }
        public AlarmTester TemperatureRateTester { get { return temperatureTester; } }

        public void ReadingTest(IPatientData reading)
        {
            if (breathingTester.ValueOutsideLimits (reading.BreathingRate))
            {
                if (BreathingRateAlarm != null) BreathingRateAlarm(this, null); 
            }
            if (diastolicTester.ValueOutsideLimits (reading.DiastolicRate))
            {
                if (DiastolicRateAlarm != null) DiastolicRateAlarm(this, null);
            }
            if (pulseTester.ValueOutsideLimits (reading.PulseRate))
            {
                if (PulseRateAlarm != null) PulseRateAlarm(this, null);
            }
            if (systolicTester.ValueOutsideLimits (reading.SystolicRate))
            {
                if (SystolicRateAlarm != null) SystolicRateAlarm(this, null);
            }
            if (temperatureTester.ValueOutsideLimits (reading.TemperatureRate))
            {
                if (TemperaturerateAlarm != null) TemperaturerateAlarm(this, null);
            }
        }

    }
}
