using System;
using System.Windows;
using System.Windows.Controls;

namespace NewPatientMonitor
{
    /// <summary>
    /// Interaction logic for UpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public event EventHandler ValueChanged;

        private int _numValue = 0;
        public int AlarmValue
        {
            get{return _numValue;}
            set
            {
                _numValue = value;
                textValue.Content = value.ToString();
            }
        }

        public NumericUpDown()
        {
            InitializeComponent();
            textValue.Content = "0";
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            textValue.Content = ++AlarmValue;
            if (ValueChanged != null) ValueChanged(this, null);
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            textValue.Content = --AlarmValue;
            if (ValueChanged != null) ValueChanged(this, null);
        }
    }
}
