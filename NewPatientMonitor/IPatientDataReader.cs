using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    interface IPatientDataReader
    {
        string memberName { get; set; }

        void connect();
        string getData();
        void setPatientData();
    }
}
