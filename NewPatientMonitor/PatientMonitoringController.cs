using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NewPatientMonitor
{
    public class PatientMonitoringController : IPatientMonitoringController
    {
        private readonly Bay _bay = new Bay();
        private readonly MainWindow _mainWindow;
        private readonly IPatientFactory _patientFactory;
        private PatientAlarmer _alarmer;

        private readonly CheckBox _alarmMuter;
        private readonly Label _breathingRate;
        private PatientDataReader _dataReader;
        private readonly Label _diastolicPressure;
        private PatientData _patientData;
        private readonly Label _pulseRate;
        private readonly Label _systolicPressure;
        private readonly Label _temperature;
        private readonly DispatcherTimer _tickTimer = new DispatcherTimer();

        public PatientMonitoringController(MainWindow window, IPatientFactory patientFactory)
        {
            _patientFactory = patientFactory;
            _mainWindow = window;
            _pulseRate = _mainWindow.pulseRate;
            _breathingRate = _mainWindow.breathingRate;
            _systolicPressure = _mainWindow.systolic;
            _diastolicPressure = _mainWindow.diastolic;
            _temperature = _mainWindow.temperature;
            _alarmMuter = _mainWindow.AlarmMute;
        }

        public void RunMonitor()
        {
            SetupComponents();
            SetupUi();
        }

        private void SetupUi()
        {
            _mainWindow.patientSelector.SelectionChanged
                += NewPatientSelected;

            _mainWindow.heartRateLower.AlarmValue = (int) DefaultSettings.DefaultModules[0].LowerLimit;
            _mainWindow.breathingRateLower.AlarmValue = (int) DefaultSettings.DefaultModules[1].LowerLimit;
            _mainWindow.temperatureLower.AlarmValue = (int) DefaultSettings.DefaultModules[2].LowerLimit;
            _mainWindow.systolicLower.AlarmValue = (int) DefaultSettings.DefaultModules[3].LowerLimit;
            _mainWindow.diastolicLower.AlarmValue = (int) DefaultSettings.DefaultModules[4].LowerLimit;

            _mainWindow.heartRateUpper.AlarmValue = (int) DefaultSettings.DefaultModules[0].UpperLimit;
            _mainWindow.breathingRateUpper.AlarmValue = (int) DefaultSettings.DefaultModules[1].UpperLimit;
            _mainWindow.temperatureUpper.AlarmValue = (int) DefaultSettings.DefaultModules[2].UpperLimit;
            _mainWindow.systolicUpper.AlarmValue = (int) DefaultSettings.DefaultModules[3].UpperLimit;
            _mainWindow.diastolicUpper.AlarmValue = (int) DefaultSettings.DefaultModules[4].UpperLimit;

            _mainWindow.heartRateLower.ValueChanged += LimitsChanged;
            _mainWindow.breathingRateLower.ValueChanged += LimitsChanged;
            _mainWindow.temperatureLower.ValueChanged += LimitsChanged;
            _mainWindow.systolicLower.ValueChanged += LimitsChanged;
            _mainWindow.diastolicLower.ValueChanged += LimitsChanged;

            _mainWindow.heartRateUpper.ValueChanged += LimitsChanged;
            _mainWindow.breathingRateUpper.ValueChanged += LimitsChanged;
            _mainWindow.temperatureUpper.ValueChanged += LimitsChanged;
            _mainWindow.systolicUpper.ValueChanged += LimitsChanged;
            _mainWindow.diastolicUpper.ValueChanged += LimitsChanged;
        }

        private void LimitsChanged(object sender, EventArgs e)
        {
            _alarmer.AlarmTesters[0].LowerLimit = _mainWindow.heartRateLower.AlarmValue;
            _alarmer.AlarmTesters[1].LowerLimit = _mainWindow.breathingRateLower.AlarmValue;
            _alarmer.AlarmTesters[2].LowerLimit = _mainWindow.temperatureLower.AlarmValue;
            _alarmer.AlarmTesters[3].LowerLimit = _mainWindow.systolicLower.AlarmValue;
            _alarmer.AlarmTesters[4].LowerLimit = _mainWindow.diastolicLower.AlarmValue;

            _alarmer.AlarmTesters[0].UpperLimit = _mainWindow.heartRateUpper.AlarmValue;
            _alarmer.AlarmTesters[1].UpperLimit = _mainWindow.breathingRateUpper.AlarmValue;
            _alarmer.AlarmTesters[2].UpperLimit = _mainWindow.temperatureUpper.AlarmValue;
            _alarmer.AlarmTesters[3].UpperLimit = _mainWindow.systolicUpper.AlarmValue;
            _alarmer.AlarmTesters[4].UpperLimit = _mainWindow.diastolicUpper.AlarmValue;
        }

        private void SetupComponents()
        {
            _patientData = (PatientData) _patientFactory.CreateAndReturnObj(PatientClassesEnumeration.PatientData);
            _dataReader =
                (PatientDataReader) _patientFactory.CreateAndReturnObj(PatientClassesEnumeration.PatientDataReader);
            _alarmer = (PatientAlarmer) _patientFactory.CreateAndReturnObj(PatientClassesEnumeration.PatientAlarmer);

            _alarmer.ModuleAlarm += SoundMutableAlarm;

            _tickTimer.Stop();
            _tickTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _tickTimer.Tick += UpdateReadings;
        }

        private void UpdateReadings(object sender, EventArgs e)
        {
            _patientData.SetPatientData(_dataReader.GetData());
            _pulseRate.Content = _patientData.Values[0];
            _breathingRate.Content = _patientData.Values[1];
            _systolicPressure.Content = _patientData.Values[2];
            _diastolicPressure.Content = _patientData.Values[3];
            _temperature.Content = _patientData.Values[4];

            var monitorList = _bay.GetListOfBedsideMonitors();

            _alarmer.ReadingTest(_patientData, monitorList[0]);
        }

        private void NewPatientSelected(object sender, SelectionChangedEventArgs e)
        {
            _tickTimer.Stop();
            var fileName = @"..\..\..\" + _mainWindow.patientSelector.SelectedValue + ".csv";
            _dataReader.Connect(fileName);
            _tickTimer.Start();
        }

        private void SoundMutableAlarm(object sender, EventArgs e)
        {
            if (_alarmMuter.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
        }
    }
}