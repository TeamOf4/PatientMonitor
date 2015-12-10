using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using NewPatientMonitor;

namespace NewPatientMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer mutable = new SoundPlayer(NewPatientMonitor.Properties.Resources.Mutable);
        SoundPlayer nonMutable = new SoundPlayer(NewPatientMonitor.Properties.Resources.NonMutable);

        public MainWindow()
        {
            InitializeComponent();
            PatientFactory factory = new PatientFactory();
            NewPatientMonitoringController controller = new NewPatientMonitoringController(this, factory);
            controller.RunMonitor();
        }

        public object Modules { get; set; }

        public void soundMutableAlarm()
        {
            mutable.Stop();
            mutable.Play();
        }

        public void soundNonMutableAlarm()
        {
            nonMutable.Stop();
            nonMutable.Play();
        }
    }
}
