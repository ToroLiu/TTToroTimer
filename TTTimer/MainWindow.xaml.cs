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
using System.Diagnostics;

using System.Windows.Threading;

namespace TTTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double _runSecs { get; set; }
        public bool _running { get; set; }
        public DispatcherTimer _timer = null;

        private void UpdateTimer()
        {
            TimeSpan curTime = TimeSpan.FromSeconds(_runSecs);
            lblTime.Content = curTime.ToString();
        }
        
        public MainWindow()
        {
            InitializeComponent();

            _runSecs = 0;
            _running = false;
            btnRun.Content = "Start";
            
            _timer = new DispatcherTimer()
            {
               Interval = new TimeSpan(0,0,1),
            };
            _timer.Tick += delegate {
                _runSecs += 1.0;
                UpdateTimer();
            };

            UpdateTimer();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if (_running)
            {
                // stop running
                _timer.Stop();
                btnReset.IsEnabled = true;
                btnRun.Content = "Start";
                _running = false;
            }
            else { 
                // start running
                _timer.Start();
                btnReset.IsEnabled = false;
                btnRun.Content = "Stop";
                _running = true;
            }

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Debug.Assert(_running == false);

            _runSecs = 0;
            UpdateTimer();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
