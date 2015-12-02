using System;
using System.IO;

namespace NewPatientMonitor
{
    public class PatientDataReader : IPatientDataReader
    {
        StreamReader _datafile;

        public PatientDataReader()
        {

        }

        public PatientDataReader(string fileName)
        {
            _datafile = new StreamReader(fileName);

            _datafile.ReadLine();
            // throw new NotImplementedException();
            // to do initialization
        }

        public string MemberName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Connect (string fileName)
        {
            _datafile = new StreamReader(fileName);

            _datafile.ReadLine();
            // throw new NotImplementedException();
            // to do initialization
        }

        public string GetData()
        {
            return _datafile.ReadLine();
            // throw new NotImplementedException();
            // to do initialization
        }

        public void SetPatientData()
        {
            throw new NotImplementedException();
        }
    }
}
