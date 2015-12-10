/*
* Interface class for the Patient Data class
* Contains a list of values as a float
* Gets the float values (NW)
*/

using System.Collections.Generic;

namespace NewPatientMonitor
{
    public interface IPatientData
    {
        List<float> Values { get; }
    }
}