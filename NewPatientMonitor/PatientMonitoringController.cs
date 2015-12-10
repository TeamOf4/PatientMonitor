using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;
using NewPatientMonitor;

namespace NewPatientMonitor
{
    class NewPatientMonitoringController
    {
        readonly MainWindow _mainWindow = null;
        readonly IPatientFactory _patientFactory = null;
        DispatcherTimer _tickTimer = new DispatcherTimer();
        PatientDataReader _dataReader;
        PatientData _patientData;
        PatientAlarmer _alarmer;

        readonly Bay _bay = new Bay();

        CheckBox _alarmMuter;
        Label _pulseRate;
        Label _breathingRate;
        Label _systolicPressure;
        Label _diastolicPressure;
        Label _temperature;

        public NewPatientMonitoringController(MainWindow window, IPatientFactory patientFactory)
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
            setupComponents();
            setupUI();
        }

        void setupUI()
        {
            _mainWindow.patientSelector.SelectionChanged
                += new System.Windows.Controls.SelectionChangedEventHandler(newPatientSelected);

            _mainWindow.heartRateLower.AlarmValue = (int)DefaultSettings.DefaultModules[0].LowerLimit;
            _mainWindow.breathingRateLower.AlarmValue = (int)DefaultSettings.DefaultModules[1].LowerLimit;
            _mainWindow.temperatureLower.AlarmValue = (int)DefaultSettings.DefaultModules[2].LowerLimit;
            _mainWindow.systolicLower.AlarmValue = (int)DefaultSettings.DefaultModules[3].LowerLimit;
            _mainWindow.diastolicLower.AlarmValue = (int)DefaultSettings.DefaultModules[4].LowerLimit;

            _mainWindow.heartRateUpper.AlarmValue = (int) DefaultSettings.DefaultModules[0].UpperLimit;
            _mainWindow.breathingRateUpper.AlarmValue = (int)DefaultSettings.DefaultModules[1].UpperLimit;
            _mainWindow.temperatureUpper.AlarmValue = (int)DefaultSettings.DefaultModules[2].UpperLimit;
            _mainWindow.systolicUpper.AlarmValue = (int)DefaultSettings.DefaultModules[3].UpperLimit;
            _mainWindow.diastolicUpper.AlarmValue = (int)DefaultSettings.DefaultModules[4].UpperLimit;

            _mainWindow.heartRateLower.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.breathingRateLower.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.temperatureLower.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.systolicLower.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.diastolicLower.ValueChanged += new EventHandler(limitsChanged);

            _mainWindow.heartRateUpper.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.breathingRateUpper.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.temperatureUpper.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.systolicUpper.ValueChanged += new EventHandler(limitsChanged);
            _mainWindow.diastolicUpper.ValueChanged += new EventHandler(limitsChanged);
        }

        void limitsChanged(object sender, EventArgs e)
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

        void setupComponents()
        {
            _patientData = (PatientData)_patientFactory.CreateAndReturnObj(PatientClassesEnumeration.PatientData);
            _dataReader = (PatientDataReader)_patientFactory.CreateAndReturnObj(PatientClassesEnumeration.PatientDataReader);
            _alarmer = (PatientAlarmer)_patientFactory.CreateAndReturnObj(PatientClassesEnumeration.PatientAlarmer);

            _alarmer.ModuleAlarm += new EventHandler(soundMutableAlarm);
            
            _tickTimer.Stop();
            _tickTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _tickTimer.Tick += new EventHandler(updateReadings);
        }

        void updateReadings(object sender, EventArgs e)
        {
            _patientData.SetPatientData(_dataReader.GetData());
            _pulseRate.Content = _patientData.Values[0];
            _breathingRate.Content = _patientData.Values[1];
            _systolicPressure.Content = _patientData.Values[2];
            _diastolicPressure.Content = _patientData.Values[3];
            _temperature.Content = _patientData.Values[4];

            List<IBedsideMonitor> monitorList = _bay.GetListOfBedsideMonitors();
            
            _alarmer.ReadingTest(_patientData, monitorList[0]);
        }

        void newPatientSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _tickTimer.Stop();
            string fileName = @"..\..\..\" + _mainWindow.patientSelector.SelectedValue + ".csv";
            _dataReader.Connect(fileName);
            _tickTimer.Start();
        }

        void soundMutableAlarm(object sender, EventArgs e)
        {
            if (_alarmMuter.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
        }
    }
}
