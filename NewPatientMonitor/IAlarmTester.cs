namespace NewPatientMonitor
{
    public interface IAlarmTester
    {
        float LowerLimit { get; set; }
        string NameOfAlarm { get; }
        //IModule TestModule { get; set; }
        float UpperLimit { get; set; }

        bool ValueOutsideLimits(float value);
    }
}