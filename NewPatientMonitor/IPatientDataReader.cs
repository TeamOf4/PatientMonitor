namespace NewPatientMonitor
{
    internal interface IPatientDataReader
    {
        string MemberName { get; set; }

        void Connect();
        string GetData();
        void SetPatientData();
    }
}