using System.Collections.Generic;
using System.Windows.Documents;

namespace NewPatientMonitor
{
    // This is the default settings or values for the Patient Monitor Program.
    public struct DefaultSettings
    {
        public static readonly List<IModule> DefaultModules = new List<IModule>(5)
        {
            new Module("Breathing Rate", 12f, 19f),
            new Module("Diastolic Rate", 70f, 95f),
            new Module("Pulse Rate", 55f, 80f),
            new Module("Systolic Rate", 120f, 140f),
            new Module("Temperature Rate", 35.5f, 38.5f),
        };        

        public static readonly IModule DefaultNewModule = new Module("New Module",10f,30f);

        public const int NumberOfBeds = 8;
        public const int NumberOfModulesInAMonitor = 4;
    }
}