using System;
namespace NewPatientMonitor
{
    public interface IModule
    {
        float LowerLimit { get; set; }
        string Name { get; set; }
        float UpperLimit { get; set; }
    }
}
