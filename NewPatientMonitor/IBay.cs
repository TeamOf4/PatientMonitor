/* Interface for bay class
    A bay stores a number of bedside monitors. A bay can be created with the default number of beds from default settings, or can be created with an int value specifying the number
    of bedside monitors. Adding and removing beds is done with AddBedSideMonitor() and RemoveBedsideMonitor(). J.S
    */

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