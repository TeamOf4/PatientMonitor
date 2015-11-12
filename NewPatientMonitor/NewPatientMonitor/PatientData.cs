using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPatientMonitor
{
    public class PatientData : IPatientData
    {
        public float BreathingRate { get; private set; }
        public float DiastolicRate { get; private set; }
        public float PulseRate { get; private set; }
        public float SystolicRate { get; private set; }
        public float TemperatureRate { get; private set; }

        public PatientData (string patientData)
        {
            SetPatientData(patientData);
        }

        public PatientData()
        {

        }

        // The code below sets up the patient data
        public void SetPatientData(string patientData)
        {
            string[] dataItems = patientData.Split(',');
            PulseRate = float.Parse(dataItems[0]);
            BreathingRate = float.Parse(dataItems[1]);
            SystolicRate = float.Parse(dataItems[2]);
            DiastolicRate = float.Parse(dataItems[3]);
            TemperatureRate = float.Parse(dataItems[4]);
        }
    }

    
}
