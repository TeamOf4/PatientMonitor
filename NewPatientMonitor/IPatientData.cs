using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IPatientData
    {
        List<float> Values { get; }
        
        //float BreathingRate { get; }
        //float DiastolicRate { get; }
        //float PulseRate { get; }
        //float SystolicRate { get; }
        //float TemperatureRate { get; }
    }
}
