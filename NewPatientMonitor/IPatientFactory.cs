/*
* Returns patient classes J.S
*/

namespace NewPatientMonitor
{
    public interface IPatientFactory
    {
        object CreateAndReturnObj(PatientClassesEnumeration objectToGet);
    }
}