using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewPatientMonitor
{
    public class PatientDataReader : IPatientDataReader
    {
        StreamReader datafile;

        public PatientDataReader()
        {

        }

        public PatientDataReader(string fileName)
        {
            datafile = new StreamReader(fileName);

            datafile.ReadLine();
            // throw new NotImplementedException();
            // to do initialization
        }

        public string memberName
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

        public void connect()
        {
            throw new NotImplementedException();
        }

        public void Connect (string fileName)
        {
            datafile = new StreamReader(fileName);

            datafile.ReadLine();
            // throw new NotImplementedException();
            // to do initialization
        }

        public string getData()
        {
            return datafile.ReadLine();
            // throw new NotImplementedException();
            // to do initialization
        }

        public void setPatientData()
        {
            throw new NotImplementedException();
        }
    }
}
