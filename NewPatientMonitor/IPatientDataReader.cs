/*
* Interface class for the Patient Data Reader
* Function called connect which passes in a string called fileName
* Returns a method called GetData, which allows the program to obtain the data from the fileName (NW)
*/
namespace NewPatientMonitor
{
    public interface IPatientDataReader
    {
        void Connect(string fileName);
        string GetData();
    }
}