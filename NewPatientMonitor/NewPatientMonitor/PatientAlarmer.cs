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
    }
}
