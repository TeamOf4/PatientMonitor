namespace NewPatientMonitor
{
    public interface IPatientDataAccessor
    {
        IPatientAlarmer AlarmToBeStored { get; set; }
        int BedNumber { get; set; }

        void WriteData(IPatientAlarmer alarmToBeStored);
        void ReadData(int bedNumber);
    }
}