using System;
using System.IO;

namespace NewPatientMonitor
{
    public class PatientDataReader : IPatientDataReader
    {
        private StreamReader _datafile;

        public PatientDataReader()
        {
        }

        public PatientDataReader(string fileName)
        {
            Connect(fileName);
        }

        public string GetData()
        {
            return _datafile.ReadLine();

        }

        public void Connect(string fileName)
        {
            _datafile = new StreamReader(fileName);

            _datafile.ReadLine();
        }
    }
}