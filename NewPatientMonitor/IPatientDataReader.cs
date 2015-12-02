namespace NewPatientMonitor
{
    interface IPatientDataReader
    {
        string MemberName { get; set; }

        void Connect();
        string GetData();
        void SetPatientData();
    }
}
