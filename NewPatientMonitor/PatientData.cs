using System.Collections.Generic;

namespace NewPatientMonitor
{
    public class PatientData : IPatientData
    {
        public List<float>  Values { get; set; } = new List<float>();

        //public float BreathingRate { get; private set; }
        //public float DiastolicRate { get; private set; }
        //public float PulseRate { get; private set; }
        //public float SystolicRate { get; private set; }
        //public float TemperatureRate { get; private set; }

        public PatientData (string patientData)
        {
            SetPatientData(patientData);
        }

        public PatientData()
        {

        }

        // receives string of patientData
        public void SetPatientData(string patientData)
        { 
            // creates an array of strings from patientData seperated by commas
            string[] dataItems = patientData.Split(',');
            // Loops through the number of modules and adds them to the values list
            for (int i = 0; i < 4; i++)
            {
                Values.Add(float.Parse(dataItems[i]));

            }

            //PulseRate = float.Parse(dataItems[0]);
            //BreathingRate = float.Parse(dataItems[1]);
            //SystolicRate = float.Parse(dataItems[2]);
            //DiastolicRate = float.Parse(dataItems[3]);
            //TemperatureRate = float.Parse(dataItems[4]);
        }
    }

    
}
