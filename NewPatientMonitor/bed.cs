using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class bed
    {
        public List<BedsideMonitor> beds { get; set; } = new List<BedsideMonitor>();
        
        public bed()
        {
            for(int i = 0; i < 8; i++)
            {
                createBed();
            }

            for (int i = 0; i < beds.Count(); i++)
            {
                beds[i].AddModule(new Module(DefaultSettings.BREATHING_RATE_NAME, DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE));
                beds[i].AddModule(new Module(DefaultSettings.DIASTOLIC_RATE_NAME, DefaultSettings.LOWER_DIASTOLIC_RATE, DefaultSettings.UPPER_DIASTOLIC_RATE));
                beds[i].AddModule(new Module(DefaultSettings.PULSE_RATE_NAME, DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE));
                beds[i].AddModule(new Module(DefaultSettings.SYSTOLIC_RATE_NAME, DefaultSettings.LOWER_SYSTOLIC_RATE, DefaultSettings.UPPER_SYSTOLIC_RATE));
            }
        }
        public void createBed()
        {
            beds.Add(new BedsideMonitor());
        }

        public void removeBed(int index)
        {
            beds.RemoveAt(index);
        }

        
    }
}
