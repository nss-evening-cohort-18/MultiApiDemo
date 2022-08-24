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
using MutliApiDemoLibrary;

namespace MultiApiDemoUI
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {

        public SunInfo()
        {
            InitializeComponent();
        }

        private async void loadSunInfo_Click(object sender, RoutedEventArgs e)
        {
            var data = await SunProcessor.LoadSunInformation(latitudeTextBox.Text, longitudeTextBox.Text);

            suriseText.Text = $"Sunrise is at {data.Sunrise.ToLocalTime().ToShortTimeString()}";
            sunsetText.Text = $"Sunset is at {data.Sunset.ToLocalTime().ToShortTimeString()}";
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckLoadButtonStatus(object sender, TextChangedEventArgs e)
        {
            loadSunInfo.IsEnabled = (latitudeTextBox.Text.Length > 0 && longitudeTextBox.Text.Length > 0);
        }
    }
}
