using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Modules class to create new monitors 
 *  Each module has a name string and an upper and lower value
 *  These values can be set when a module is created or updated later
 *  If a module is created without these values default values from DefaultSettings will be used
 */ 

namespace NewPatientMonitor
{
    public class Module : IModule
    {
        private string name;
        public string Name { get {return name; } set {name = value;} }

        private float lowerLimit;
        public float LowerLimit { get { return lowerLimit; } set { lowerLimit = value; } }

        private float upperLimit;
        public float UpperLimit { get { return upperLimit; } set { upperLimit = value; } }

        public Module()
        {
            Name = DefaultSettings.NEW_MODULE_NAME;
            LowerLimit = DefaultSettings.LOWER_DEFAULT_VALUE;
            UpperLimit = DefaultSettings.UPPER_DEFAULT_VALUE;

        }

        public Module(string name)
        {
            Name = name;
            LowerLimit = DefaultSettings.LOWER_DEFAULT_VALUE;
            UpperLimit = DefaultSettings.UPPER_DEFAULT_VALUE;
        }

        public Module(string name, float lowerLimit, float upperLimit)
        {
            Name = name;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
