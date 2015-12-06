using System.Collections.Generic;

/*
Stores a list of Modules installed in the bedside monitor. Can add and remove Modules from
the bedside monitor
*/

namespace NewPatientMonitor
{
    public class BedsideMonitor : IBedsideMonitor
    {
        private Module ModuleToBeAdded = new Module();

        public List<IModule> BedsideModules { get; set; } = new List<IModule>(DefaultSettings.NumberOfModulesInAMonitor);

        public BedsideMonitor()
        {
            var defaultModule = new Module();

            for (int i = 0; i < DefaultSettings.NumberOfModulesInAMonitor; i++)
            {
                AddModule(new Module(DefaultSettings.DefaultModules[i]));

            }
        }

        public void AddModule(IModule moduleToBeAdded)
        {
            if (BedsideModules.Count < DefaultSettings.NumberOfModulesInAMonitor)
            {
                BedsideModules.Add(moduleToBeAdded);
            }

            else
            {
                ChangeModule(DefaultSettings.NumberOfModulesInAMonitor - 1, moduleToBeAdded);
            }
        }


        public void RemoveModule(int indexOfModuleToBeRemoved)
        {
            BedsideModules.RemoveAt(indexOfModuleToBeRemoved);
        }

        public void ChangeModule(int indexOfModule, IModule moduleToBeAdded)
        {
            RemoveModule(indexOfModule);
            BedsideModules.Insert(indexOfModule, moduleToBeAdded);
        }

        public List<IModule> GetListOfModules()
        {
            return BedsideModules;
        }
    }
}