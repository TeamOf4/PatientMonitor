using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class PatientMonitoringController
    {
        public void main()
        {
            List<BedsideMonitor> beds = new List<BedsideMonitor>();
            List<Module> modules = new List<Module>();
            modules.Add(new Module(DefaultSettings.BREATHING_RATE_NAME, DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE));
            modules.Add(new Module(DefaultSettings.DIASTOLIC_RATE_NAME, DefaultSettings.LOWER_DIASTOLIC_RATE, DefaultSettings.UPPER_DIASTOLIC_RATE));
            modules.Add(new Module(DefaultSettings.PULSE_RATE_NAME, DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE));
            modules.Add(new Module(DefaultSettings.SYSTOLIC_RATE_NAME, DefaultSettings.LOWER_SYSTOLIC_RATE, DefaultSettings.UPPER_SYSTOLIC_RATE));
            modules.Add(new Module(DefaultSettings.TEMPERATURE_RATE_NAME, DefaultSettings.LOWER_TEMPERATURE_RATE, DefaultSettings.UPPER_TEMPERATURE_RATE));

            for (int i = 0; i < 8; i++)
            {
                beds.Add(new BedsideMonitor());
                beds[i].AddModule(modules[0]);
                beds[i].AddModule(modules[1]);
                beds[i].AddModule(modules[2]);
                beds[i].AddModule(modules[3]);

            }

        }
    }
}
