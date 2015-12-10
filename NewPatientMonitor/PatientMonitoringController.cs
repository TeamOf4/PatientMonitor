using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NewPatientMonitor
{
    public class PatientMonitoringController
    {
        readonly MainWindow _mainWindow = null;
        private readonly IPatientFactory _patientFactory = null;
        readonly DispatcherTimer _tickTimer = new DispatcherTimer();
        PatientDataReader _dataReader;
        PatientDataWriter _dataWriter;
        PatientData _patientData;
        PatientAlarmer _alarmer;

        CheckBox _alarmMuter;
        List<Label> _modules;

        public PatientMonitoringController(MainWindow window, IPatientFactory patientFactory)
        {
            _mainWindow = window;
            _patientFactory = patientFactory;
            _alarmMuter = _mainWindow.AlarmMute;
            _modules = _mainWindow.Modules;
        }

        public void RunMonitor()
        {
            setupComponents();
            SetupUi();
        }

        void SetupUi()
        {
            _mainWindow.patientSelector.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(NewPatientSelected);


        }

        void LimitsChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void setupComponents()
        {
            throw new NotImplementedException();
        }

        void UpdateReadings(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void NewPatientSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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