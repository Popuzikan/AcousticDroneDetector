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
using System.Windows.Threading;
using AcusticDetector.ChartSetting;
using AcusticDetector.DataService;
using AcusticDetector.Processing;
using MindFusion.RealTimeCharting.Wpf;

namespace AcusticDetector.Models
{
    /// <summary>
    /// Логика взаимодействия для ViewCharting.xaml
    /// </summary>
    public partial class ViewCharting : UserControl
    {
        private int _rate;

        private int _buffrsize;

        private Point[] points1;

        private DataTools _data;

        private Series series1 = null;

        private DispatcherTimer dispatcherTimer;
 
        public ViewCharting(int rate, int buffersize, DataTools data) {  
            
            InitializeComponent();
                        
            _rate = rate;
            _buffrsize = buffersize;
            _data = data;
                 
            ChartInitialize.InitChart(chart1, ref series1, _rate);

            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Send);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(((double)_buffrsize / _rate * 1000.0));
            dispatcherTimer.Tick += dispatcherTimer_Tick;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) {

            if (_data.IsActive.IsDeviceEnable) {
                chart1.FastScrollMode = true;

                PlotLatestData();
            }
        }

        private void chart1_MouseWheel(object sender, MouseWheelEventArgs e) {
            try {
                chart1.YAxisCollection[0].Length += e.Delta > 0 ? points1.Max(y => y.Y) / 4 : -points1.Max(y => y.Y) / 4;
                chart1.YAxisCollection[0].Interval = chart1.YAxisCollection[0].Length / 4;
            }
            catch { }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e) =>
                     chart1.ShowCrosshairs = e.MouseDevice.LeftButton.Equals(MouseButtonState.Pressed) ? true : false;

        private void chart1_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.MouseDevice.RightButton == MouseButtonState.Pressed)
                try {
                    chart1.YAxisCollection[0].Length = points1.Max(y => y.Y);
                    chart1.YAxisCollection[0].Interval = chart1.YAxisCollection[0].Length / 4;

                    chart1.Commit();
                }
                catch { }
        }

        private void PlotLatestData() {

            if (_data != null) {

                points1 = _data?.FastFurierTransforms(_rate, _buffrsize);

                series1?.Data?.AddRange(points1);

                chart1?.Commit(0);

                series1?.Data?.RemoveRange(0, points1.Length);
            }
            else
                MessageBox.Show("Microphones is not connected");

        }
        public void StartView() => dispatcherTimer.Start();
        public void StoptView() => dispatcherTimer.Stop(); 
    }
}
