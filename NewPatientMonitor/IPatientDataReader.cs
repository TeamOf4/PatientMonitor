namespace NewPatientMonitor
{
    public interface IPatientDataReader
    {
        void Connect(string fileName);
        string GetData();
    }
}