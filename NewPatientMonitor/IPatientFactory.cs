namespace NewPatientMonitor
{
    interface IPatientFactory
    {
         object CreateAndReturnObj(PatientClassesEnumeration objectToGet);
    }
}
