using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IBay
    {
        List<BedsideMonitor> Beds { get; set; }
        int NumberOfBeds { get; set; }

        void AddBedSideMonitor();
        void RemoveBedsideMonitor(int index);
    }
}