/*
* Interface for bedside monitor
* Contains a list of bedside modules
* Contains functions to add and remove modules to/from the list, and to swap a module in the list
* Contains functions to return the list of modules in this bedside monitor
*/

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