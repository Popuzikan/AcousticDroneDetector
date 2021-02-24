using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Timers;
using AcusticDetector.Interfaces;

namespace AcusticDetector.Processing
{
    class Radar: INotifyPropertyChanged, IStartRadar,IStopRadar
    {
        private int _angle;
        private int _value;

        public int Angle {
            get {
                return _angle;
            }

            set {
                _angle = value;
                NotifyPropertyChanged("Angle");
            }
        }
        public int Value {
            get {
                return _value;
            }

            set {
                _value = value;
                    
                NotifyPropertyChanged("Value");
            }
        }

        public Timer TimeDetect { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
       
        public Radar()
        {            
            Value = 0;

            TimeDetect = new Timer();

            TimeDetect.Interval = 10; 

            TimeDetect.Elapsed += Detect;     
        }
        private void Detect(object sender, ElapsedEventArgs e) => Value++;
        
        private void NotifyPropertyChanged(string info) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

        public void Start() => TimeDetect.Start();
        public void Stop() => TimeDetect.Stop();
 
    }
}
