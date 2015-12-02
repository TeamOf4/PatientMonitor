/* Modules class to create new monitors 
 *  Each module has a name string and an upper and lower value
 *  These values can be set when a module is created or updated later
 *  If a module is created without these values default values from DefaultSettings will be used
 */ 

namespace NewPatientMonitor
{
    public class Module : IModule
    {
        public string Name { get; set; }

        public float LowerLimit { get; set; }

        public float UpperLimit { get; set; }

        public Module()
        {
            Name = DefaultSettings.NewModuleName;
            LowerLimit = DefaultSettings.LowerDefaultValue;
            UpperLimit = DefaultSettings.UpperDefaultValue;

        }

        public Module(string name)
        {
            Name = name;
            LowerLimit = DefaultSettings.LowerDefaultValue;
            UpperLimit = DefaultSettings.UpperDefaultValue;
        }

        public Module(string name, float lowerLimit, float upperLimit)
        {
            Name = name;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
