/* Interface for module class
*  Stores the name, and lower and upper limit of each module.
*  J.S
*/

namespace NewPatientMonitor
{
    public interface IModule
    {
        float LowerLimit { get; set; }
        string Name { get; set; }
        float UpperLimit { get; set; }
    }
}