namespace NewPatientMonitor
{
    public interface IPatientDataWriter
    {
        IPatientAlarmer AlarmToBeStored { get; set; }
        int BedNumber { get; set; }

        void WriteData(IPatientAlarmer alarmToBeStored);
        void ReadData(int bedNumber);
    }
}