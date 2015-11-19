using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class BedsideMonitor
    {
        public Module ModuleToBeAdded = new Module();

        public List<IModule> Bedsidemodules
        {

            get;
            set;
        } = new List<IModule>();

        public void AddMonitor(IModule moduleToBeAdded)
        {
            Bedsidemodules.Add(moduleToBeAdded);
        }

        public void RemoveMonitor(int indexOfModuleToBeRemoved)
        {
            Bedsidemodules.RemoveAt(indexOfModuleToBeRemoved);
        }
    }
}
