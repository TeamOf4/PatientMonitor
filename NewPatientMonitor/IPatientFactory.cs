namespace NewPatientMonitor
{
    internal interface IPatientFactory
    {
        object CreateAndReturnObj(PatientClassesEnumeration objectToGet);
    }
}