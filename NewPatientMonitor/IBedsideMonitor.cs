using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IBedsideMonitor
    {
        List<IModule> BedsideModules { get; set; }

        void AddModule(IModule moduleToBeAdded);
        void ChangeModule(int indexOfModule, IModule moduleToBeAdded);
        List<IModule> GetListOfModules();
        void RemoveModule(int indexOfModuleToBeRemoved);
    }
}