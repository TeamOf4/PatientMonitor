/*
* Interface for Alarm Tester
* Stores the LowerLimit, Name of the alarm and the UppeLimit
* Contains a function to check whether the value is outside the limits using the bool valueOutsideLimits which passes a float value (NW)
*/
namespace NewPatientMonitor
{
    public interface IAlarmTester
    {
        float LowerLimit { get; set; }
        string NameOfAlarm { get; set; }
        float UpperLimit { get; set; }

        bool ValueOutsideLimits(float value);
    }
}