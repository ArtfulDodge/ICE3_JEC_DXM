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
using System.Windows.Navigation;
using System.Windows.Shapes;
// Joshua C. and Divya M.
namespace ICE3StarterCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (rdoLinear.IsChecked == true)
            {
                DBToLinear();
            } else if (rdoDB.IsChecked == true)
            {
                LinearToDB();
            } else
            {
                MessageBoxResult errorBox = MessageBox.Show("Please click a radio button", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (txtConvert.Text.Equals(""))
            {
                MessageBoxResult errorBox = MessageBox.Show("PLEASE enter some text", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LinearToDB()
        {
            double linearInput = Double.Parse(txtConvert.Text);
            double dBOutput = 10 * Math.Log10(linearInput);
            txtConvertOutput.Text = dBOutput.ToString();
        }

        private void DBToLinear()
        {
            double dBInput = Double.Parse(txtConvert.Text);
            double linearOutput = Math.Pow(10, dBInput / 10);
            txtConvertOutput.Text = linearOutput.ToString();
        }

        private void btnComputeNoise_Click(object sender, RoutedEventArgs e)
        {
            String comboboxSelection = cboTemperatureUnit.Text;
            double temperature = Double.Parse(txtTemperature.Text);

            if (comboboxSelection.Equals("Celsius"))
            {
                temperature = CTOK(temperature);
            }
            
            if (comboboxSelection.Equals("Fahrenheit"))
            {
                temperature = FTOK(temperature);
            }
            calcNoiseInDB(temperature);
        }

        private double CTOK(double i)
        {
            return (i + 273.15);
        }

        private double FTOK(double i)
        {
            return ((i - 32) * 5 / 9 + 273.15);
        }

        private void calcNoiseInDB(double temp)
        {
            double bandwidth = Double.Parse(txtBandwidth.Text);
            bandwidth *= Math.Pow(10, 6);
            double result = -228.6 + (10 * Math.Log10(temp)) + (10 * Math.Log10(bandwidth));
            txtNoiseOutput.Text = result.ToString();
        }

        private void btnComputeNoise_Click_1(object sender, RoutedEventArgs e)
        {
            String comboboxSelection = cboTemperatureUnit.Text;
            double temperature = Double.Parse(txtTemperature.Text);

            if (comboboxSelection.Equals("Celsius"))
            {
                temperature = CTOK(temperature);
            }

            if (comboboxSelection.Equals("Fahrenheit"))
            {
                temperature = FTOK(temperature);
            }
            calcNoiseInDB(temperature);
        }
    }
}
