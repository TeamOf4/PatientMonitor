namespace NewPatientMonitor
{
    // This is the default settings or values for the Patient Monitor Program.
    public struct DefaultSettings
    {
        public const string BreathingRateName = "Breathing Rate";
        public const string DiastolicRateName = "Diastolic Rate";
        public const string PulseRateName = "Pulse Rate";
        public const string SystolicRateName = "Systolic Rate";
        public const string TemperatureRateName = "Temperature Rate";
        public const string NewModuleName = "New module";

        public const float UpperBreathingRate = 19f;
        public const float LowerBreathingRate = 12f;
        public const float UpperDiastolicRate = 95f;
        public const float LowerDiastolicRate = 70f;
        public const float UpperPulseRate = 80f;
        public const float LowerPulseRate = 55f;
        public const float UpperSystolicRate = 140;
        public const float LowerSystolicRate = 120;
        public const float UpperTemperatureRate = 38.5f;
        public const float LowerTemperatureRate = 35.5f;
        public const float UpperDefaultValue = 30.0f;
        public const float LowerDefaultValue = 10.0f;

        public const int NumberOfBeds = 8;
        public const int NumberOfModulesInAMonitor = 4;
    }
}