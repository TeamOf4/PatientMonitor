using System.Collections.Generic;
using System.Linq;

namespace NewPatientMonitor
{
    public class Bed
    {
        public List<BedsideMonitor> Beds { get; set; } = new List<BedsideMonitor>();
        
        public Bed()
        {
            for(int i = 0; i < 8; i++)
            {
                CreateBed();
            }

            for (int i = 0; i < Beds.Count(); i++)
            {
                Beds[i].AddModule(new Module(DefaultSettings.BreathingRateName, DefaultSettings.LowerBreathingRate, DefaultSettings.UpperBreathingRate));
                Beds[i].AddModule(new Module(DefaultSettings.DiastolicRateName, DefaultSettings.LowerDiastolicRate, DefaultSettings.UpperDiastolicRate));
                Beds[i].AddModule(new Module(DefaultSettings.PulseRateName, DefaultSettings.LowerPulseRate, DefaultSettings.UpperPulseRate));
                Beds[i].AddModule(new Module(DefaultSettings.SystolicRateName, DefaultSettings.LowerSystolicRate, DefaultSettings.UpperSystolicRate));
            }
        }
        public void CreateBed()
        {
            Beds.Add(new BedsideMonitor());
        }

        public void RemoveBed(int index)
        {
            Beds.RemoveAt(index);
        }

        
    }
}
