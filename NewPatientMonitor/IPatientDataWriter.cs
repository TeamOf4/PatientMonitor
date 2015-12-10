/*
* Writes data of alarm and bednumber that triggered alarm to file J.S
*/


namespace NewPatientMonitor
{
    public interface IPatientDataWriter
    {
        IPatientAlarmer AlarmToBeStored { get; set; }
        int BedNumber { get; set; }

        void WriteData(IPatientAlarmer alarmToBeStored);
    }
}