using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IBedsideMonitor
    {
        List<IModule> Bedsidemodules { get; set; }

        void AddModule(IModule moduleToBeAdded);
        void ChangeModule(int indexOfModule, IModule moduleToBeAdded);
        void RemoveModule(int indexOfModuleToBeRemoved);
    }
}