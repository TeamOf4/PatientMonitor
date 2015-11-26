using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Stores a list of modules installed in the bedside monitor. Can add and remove modules from
the bedside monitor
*/
namespace NewPatientMonitor
{
    public class BedsideMonitor : IBedsideMonitor
    {
        public Module ModuleToBeAdded = new Module();

        public List<IModule> Bedsidemodules
        {

            get;
            set;
        } = new List<IModule>();

        public void AddModule(IModule moduleToBeAdded)
        {
            Bedsidemodules.Add(moduleToBeAdded);
        }

        public void RemoveModule(int indexOfModuleToBeRemoved)
        {
            Bedsidemodules.RemoveAt(indexOfModuleToBeRemoved);
        }
    }
}
