using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public interface IAlarmTester
    {
        float LowerLimit { get; set; }
        float UpperLimit { get; set; }

        bool ValueOutsideLimits(float value);
        
    }
}
