/*
Checks if the passed in values are outside of the limit for that module.
*/

namespace NewPatientMonitor
{
    public class AlarmTester : IAlarmTester
    {
        // Creates a new instance of the AlamrTester Class within the NewPatientMonitor App.
        public AlarmTester(IModule testModule)
        {
            NameOfAlarm = testModule.Name;
            LowerLimit = testModule.LowerLimit;
            UpperLimit = testModule.UpperLimit;
        }

        // Module being tested
        //public IModule TestModule { get; set; }

        public string NameOfAlarm { get;  set; }

        public float LowerLimit { get; set; }

        // The line below gets and sets the upper limit.
        public float UpperLimit { get; set; }

        // Checks to see whether the values is outside the limits.
        //If the values is outside the limits. It will return false otherwise.
        // || OR Operator

        // If value is greater than OR less than value.
        public bool ValueOutsideLimits(float value)
        {
            // throw new NotImplementedException();

            return value > UpperLimit || value < LowerLimit;
        }
    }
}