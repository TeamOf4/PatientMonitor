using System.Collections.Generic;

namespace NewPatientMonitor
{
    /*
    A bay stores a number of bedside monitors. A bay can be created with the default number of beds from default settings, or can be created with an int value specifying the number
    of bedside monitors. Adding and removing beds is done with AddBedSideMonitor() and RemoveBedsideMonitor(). J.S
    */

    public class Bay : IBay
    {        

        public List<IBedsideMonitor> BedsideMonitors { get; set; } = new List<IBedsideMonitor>();

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
            BedsideMonitors.Add(new BedsideMonitor());
        }

        public void RemoveBedsideMonitor(int index)
        {
            BedsideMonitors.RemoveAt(index);
        }

        public List<IBedsideMonitor> GetListOfBedsideMonitors()
        {
            return BedsideMonitors;
        }
    }
}