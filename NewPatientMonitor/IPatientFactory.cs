using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    interface IPatientFactory
    {
         object createAndReturnObj(PatientClassesEnumeration objectToGet);
    }
}
