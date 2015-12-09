using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewPatientMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Label> Modules;
        public object patientSelector;

        public MainWindow()
        {
            InitializeComponent();
        }

        public CheckBox AlarmMute { get; set; }

        public void soundMutableAlarm()
        {
            throw new NotImplementedException();
        }
    }
}
