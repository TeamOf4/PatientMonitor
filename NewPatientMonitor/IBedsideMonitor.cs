using System.Collections.Generic;

namespace NewPatientMonitor
{
    interface IBedsideMonitor
    {
        List<IModule> Bedsidemodules { get; set; }

        void AddModule(IModule module);
        void RemoveModule(int moduleNumber);
    }
}
