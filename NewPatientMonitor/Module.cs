/* Modules class to create new monitors 
 *  Each module has a name string and an upper and lower value
 *  These values can be set when a module is created or updated later
 *  If a module is created without these values default values from DefaultSettings will be used
 *  J.S
 */

namespace NewPatientMonitor
{
    public class Module : IModule
    {
        public Module()
        {
            Name = DefaultSettings.DefaultNewModule.Name;
            LowerLimit = DefaultSettings.DefaultNewModule.LowerLimit;
            UpperLimit = DefaultSettings.DefaultNewModule.UpperLimit;
        }

        public Module(IModule module)
        {
            Name = module.Name;
            LowerLimit = module.LowerLimit;
            UpperLimit = module.UpperLimit;
        }

        public Module(string moduleName)
        {
            Name = moduleName;
            LowerLimit = DefaultSettings.DefaultNewModule.LowerLimit;
            UpperLimit = DefaultSettings.DefaultNewModule.UpperLimit;
        }

        public Module(string name, float lowerLimit, float upperLimit)
        {
            Name = name;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public string Name { get; set; }

        public float LowerLimit { get; set; }

        public float UpperLimit { get; set; }
    }
}