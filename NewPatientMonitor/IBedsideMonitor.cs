using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    interface IBedsideMonitor
    {
        List<IModule> Bedsidemodules { get; set; }

        void AddModule(IModule module);
        void RemoveModule(int moduleNumber);
    }
}
