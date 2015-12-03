using System;

namespace NewPatientMonitor
{
    internal class PatientDataWriter : IPatientDataWriter
    {
        public IPatientAlarmer AlarmToBeStored { get; set; }
        public int BedNumber { get; set; }
        
        public void WriteData(IPatientAlarmer alarmToBeStored)
        {
            throw new NotImplementedException();
        }

        public void ReadData(int bedNumber)
        {
            throw new NotImplementedException();
        }
    }
}