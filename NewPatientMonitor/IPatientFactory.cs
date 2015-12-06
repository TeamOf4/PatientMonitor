namespace NewPatientMonitor
{
    public interface IPatientFactory
    {
        object CreateAndReturnObj(PatientClassesEnumeration objectToGet);
    }
}