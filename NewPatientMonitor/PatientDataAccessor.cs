namespace NewPatientMonitor
{
    class PatientDataAccessor : IPatientDataAccessor
    {
        public IPatientAlarmer AlarmToBeStored { get; set; }
        public int BedNumber { get; set; }

        PatientDataAccessor()
        {
            
        }

        public void WriteData(IPatientAlarmer alarmToBeStored)
        {
            throw new System.NotImplementedException();
        }

        public void ReadData(int bedNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}