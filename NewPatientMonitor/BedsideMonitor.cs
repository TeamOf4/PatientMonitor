using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class BedsideMonitor
    {
        public List<IModule> Bedsidemodules
        {
            get;
            set;
        }

        public void AddMonitor(IModule moduleToBeAdded)
        {
            Bedsidemodules.Add(moduleToBeAdded);
        }
    }
}
