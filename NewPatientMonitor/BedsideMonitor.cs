using System.Collections.Generic;

/*
Stores a list of modules installed in the bedside monitor. Can add and remove modules from
the bedside monitor
*/

namespace NewPatientMonitor
{
    public class BedsideMonitor : IBedsideMonitor
    {
        public Module ModuleToBeAdded = new Module();

        public List<IModule> Bedsidemodules { get; set; } = new List<IModule>(4);

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
            if (Bedsidemodules.Count < DefaultSettings.NumberOfModulesInAMonitor)
            {
                Bedsidemodules.Add(moduleToBeAdded);
            }

            else
            {
                ChangeModule(DefaultSettings.NumberOfModulesInAMonitor - 1, moduleToBeAdded);
            }
        }


        public void RemoveModule(int indexOfModuleToBeRemoved)
        {
            Bedsidemodules.RemoveAt(indexOfModuleToBeRemoved);
        }

        public void ChangeModule(int indexOfModule, IModule moduleToBeAdded)
        {
            RemoveModule(indexOfModule);
            Bedsidemodules.Insert(indexOfModule, moduleToBeAdded);
        }
    }
}