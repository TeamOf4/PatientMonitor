namespace NewPatientMonitor
{
    public interface IAlarmTester
    {
        float LowerLimit { get; set; }
        float UpperLimit { get; set; }

        bool ValueOutsideLimits(float value);
    }
}