using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace NewPatientMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>




    public partial class MainWindow : Window
    {

        public List<Label> Modules;
        public ComboBox patientSelector;
        SoundPlayer mutable = new SoundPlayer(NewPatientMonitor.Properties.Resources.Mutable);
        SoundPlayer nonMutable = new SoundPlayer(NewPatientMonitor.Properties.Resources.NonMutable);

        public MainWindow()
        {
            InitializeComponent();
            PatientFactory factory = new PatientFactory();
            PatientMonitoringController controller = new PatientMonitoringController(this, factory);
            controller.RunMonitor();
        }

        public void SoundMutableAlarm()
        {
            mutable.Stop();
            mutable.Play();
        }

        public void SoundNonMutableAlarm()
        {
            nonMutable.Stop();
            nonMutable.Play();
        }
    }
}
