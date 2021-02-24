using AcusticDetector.Interfaces;
using AcusticDetector.Processing;
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

namespace AcusticDetector.Viewers
{
    /// <summary>
    /// Логика взаимодействия для ViewRadar.xaml
    /// </summary>
    public partial class ViewRadar : UserControl
    {     
        public ViewRadar() {
            InitializeComponent();

            DataContext =  new Radar();
        }

        public void Start() => (DataContext as IStartRadar).Start();
        public void Stop() => (DataContext as IStopRadar).Stop();
    }
}
