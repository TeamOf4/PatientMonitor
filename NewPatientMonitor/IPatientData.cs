using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public interface IPatientData
    {
        List<float> values { get; }
        
        //float BreathingRate { get; }
        //float DiastolicRate { get; }
        //float PulseRate { get; }
        //float SystolicRate { get; }
        //float TemperatureRate { get; }
    }
}
