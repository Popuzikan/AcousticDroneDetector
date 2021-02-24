using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using AcusticDetector.ChartSetting;
using NAudio.Wave;
using AcusticDetector.Processing;
using System.Windows.Threading;
using MindFusion.RealTimeCharting.Wpf;
using System.Threading;
using AcusticDetector.AnalogDataProvider;
using AcusticDetector.DataService;
using AcusticDetector.Models;
using AcusticDetector.Viewers;

namespace AcusticDetector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  private DispatcherTimer dispatcherTimer;

        private ViewRadar _radar = null;
        private ViewCharting _mChart = null;

        public DataTools Data { get; internal set; } = null;

        public int BuffreSize { get; private set; } = (int)Math.Pow(2, 12);
        public int Rate { get; set; } = 44100;

        public MainWindow() {

            InitializeComponent();      
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)  {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            int index = ListViewMenu.SelectedIndex;

            switch (index) {
                
                case 0:
                    _radar?.Stop();
                    _mChart?.StoptView();
                    GridChart.Children.Clear();
                    GridRadar.Children.Clear();
                    break;
                case 1:                        
                    if (Data != null) {
                        GridChart.Children.Clear();
                            
                        _mChart = new ViewCharting(Rate, BuffreSize, Data);                     
                        _radar = new ViewRadar();

                        GridChart.Children.Add(_mChart);
                        GridRadar.Children.Add(_radar);                                                  
                    }                      
                    break;        
                case 2:                                                 
                    if (Data == null) {                              
                            
                        var _microphone = new MicrophoneConnect(0, (int)((double)BuffreSize / Rate * 1000.0), new WaveFormat(Rate, 1));      
                        
                        Data = new DataTools(new InputSignalsBuffer(Rate, _microphone.InputSignal), _microphone);                            
                        Data.StartListenToMicrophone();                      
                    }                
                    break;             
                case 3:
                    if (Data != null) {
                        _radar?.Start();
                        _mChart?.StartView();
                    }
                    break;
                case 4:                                   
                        _radar?.Stop();
                        _mChart?.StoptView();
                    break;
            }
        }
    }
}
