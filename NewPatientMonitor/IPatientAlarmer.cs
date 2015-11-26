using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public interface IPatientAlarmer
    {
        List<IAlarmTester> AlarmTesters { get; set; }
        void readingTest();
    }
}
