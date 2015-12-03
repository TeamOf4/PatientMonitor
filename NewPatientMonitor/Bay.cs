using System.Collections.Generic;

namespace NewPatientMonitor
{
    public class Bay : IBay
    {        

        public List<BedsideMonitor> Beds { get; set; } = new List<BedsideMonitor>();

        public int NumberOfBeds { get; set; }

        public Bay()
        {
            NumberOfBeds = DefaultSettings.NumberOfBeds;
            CreateBedsideMonitorsInBay();
        }

        public Bay(int numberOfBeds)
        {
            NumberOfBeds = numberOfBeds;
            CreateBedsideMonitorsInBay();
        }

        private void CreateBedsideMonitorsInBay()
        {
            for (var i = 0; i < NumberOfBeds; i++)
            {
                AddBedSideMonitor();
            }
        }

        public void AddBedSideMonitor()
        {
            Beds.Add(new BedsideMonitor());
        }

        public void RemoveBedsideMonitor(int index)
        {
            Beds.RemoveAt(index);
        }
    }
}