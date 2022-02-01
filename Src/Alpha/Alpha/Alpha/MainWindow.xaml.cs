using kinect;
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

namespace Alpha
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KinectManager km { get; set; }

        public MainWindow()
        {
            km = new KinectManager();
            InitializeComponent();
            DataContext = this;
        }

        private void ConnectKinnectButton(object sender, RoutedEventArgs e)
        {
            km.Init();
            if (km.kinect.IsRunning)
                ((Button)sender).Content = "running";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            km.Stop();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            km.setKinectAngle((int)e.NewValue);
        }
    }
}
