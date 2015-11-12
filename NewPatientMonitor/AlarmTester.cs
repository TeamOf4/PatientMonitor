using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class AlarmTester
    {
        
        // The line below gets and sets the lower limit.
        public float LowerLimit
        {
            get;
            set;
        }

        // The line below gets and sets the upper limit.
        public float UpperLimit
        {
            get;
            set;
        }

        public string NameOfAlarm
        {
            get;
            private set;
        }

        // Creates a new instance of the AlamrTester Class within the NewPatientMonitor App.
        public AlarmTester (string moduleName, float initialLowerLimit, float initialUpperLimit)
        {
            NameOfAlarm = moduleName;
            LowerLimit = initialLowerLimit;
            UpperLimit = initialUpperLimit;

            // throw new NotImplementedException();


        }

        // Checks to see whether the values is outside the limits.
        //If the values is outside the limits. It will return false otherwise.
        // || OR Operator

        // If value is greater than OR less than value.
        public bool ValueOutsideLimits (float value)
        {
            // throw new NotImplementedException();

            return (false || value > UpperLimit || value < LowerLimit);
        }
        

        


    }
}
