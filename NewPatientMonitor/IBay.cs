using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IBay
    {
        List<IBedsideMonitor> BedsideMonitors { get; set; }
        int NumberOfBeds { get; set; }

        void AddBedSideMonitor();
        List<IBedsideMonitor> GetListOfBedsideMonitors();
        void RemoveBedsideMonitor(int index);
    }
}