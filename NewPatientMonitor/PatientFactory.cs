using System;

namespace NewPatientMonitor
{
    public class PatientFactory : IPatientFactory
    {
        public object CreateAndReturnObj(PatientClassesEnumeration objectToGet)
        {
            object createdObject = null;

            switch (objectToGet)
            {
                case PatientClassesEnumeration.PatientAlarmer:
                    PatientAlarmer alarmer = new PatientAlarmer();
                    createdObject = alarmer;
                    break;
                case PatientClassesEnumeration.PatientDataReader:
                    PatientDataReader dataReader = new PatientDataReader();
                    createdObject = dataReader;
                    break;
                case PatientClassesEnumeration.PatientData:
                    PatientData patientData = new PatientData();
                    createdObject = patientData;
                    break;
                case PatientClassesEnumeration.PatientDataWriter:
                    PatientDataWriter dataWriter = new PatientDataWriter();
                    createdObject = dataWriter;
                    break;
                default:
                    throw new ArgumentException("Invalid parameter passed");
            }
            return createdObject;
        }
    }
}