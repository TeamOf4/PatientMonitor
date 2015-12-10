using System;

namespace NewPatientMonitor
{
    public class PatientDataWriter : IPatientDataWriter
    {
        public IPatientAlarmer AlarmToBeStored { get; set; }
        public int BedNumber { get; set; }
        
        public void WriteData(IPatientAlarmer alarmToBeStored)
        {
            throw new NotImplementedException();
        }
    }
}