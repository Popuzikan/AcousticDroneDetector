using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcusticDetector.DataService;
using AcusticDetector.AnalogDataProvider;
using System;
using AcusticDetector.Interfaces;

namespace AcusticDetector.DataService
{
    public class DataTools
    {
        private InputSignalsBuffer _signalsBuffer;

        private MicrophoneConnect _inputData;

        public IMicConnected IsActive { get; private set; }

        public DataTools(InputSignalsBuffer dataBuffer, MicrophoneConnect microphone) {
            try {

                IsActive = _signalsBuffer = (dataBuffer != null) ? dataBuffer : null;
                _inputData = (microphone != null) ? microphone : null;
            }
            catch (NullReferenceException e) {

                MessageBox.Show(e.Message);
            }
        }
        public Point[] FastFurierTransforms(int sampleRate, int bufferLength) {  
            
            // check the incoming microphone audio
            int frameSize = bufferLength;

            var audioBytes = new byte[frameSize];

            _signalsBuffer.SignalProvider.Read(audioBytes, 0, frameSize);

            _signalsBuffer.SignalProvider.ClearBuffer();
            // return if there's nothing new to plot
            if (audioBytes.Length == 0)
                return new Point[0];

            else if (audioBytes[frameSize - 2] == 0)
                return new Point[0];

            // incoming data is 16-bit (2 bytes per audio point)
            int BYTES_PER_POINT = 2;

            // create a (32-bit) int array ready to fill with the 16-bit data
            int graphPointCount = audioBytes.Length / BYTES_PER_POINT;

            double samplesRatePerCount = (double)sampleRate / (double)graphPointCount;

            double[] pcm = new double[graphPointCount];
            double[] pcm1 = new double[graphPointCount];

            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[graphPointCount];

            for (int i = 0; i < graphPointCount; i++) {

                Int16 timeVal = BitConverter.ToInt16(audioBytes, i * 2);

                fftComplex[i] = new System.Numerics.Complex(FilterTools.HightPassFilter(timeVal/ Math.Pow(2, 12) * 200.0), 0.0);
            }

            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);

            return ComplexToPoint(fftComplex, samplesRatePerCount, graphPointCount);
        }
        
        private Point [] ComplexToPoint(System.Numerics.Complex[] complices, double samplesRatePerCount, int _graphPointCount) {      

            var points1 = new Point[_graphPointCount / 20];

            for (int i = 0; i < complices.Length / 20; i++) {

                points1[i].Y = complices[i].Magnitude;
                points1[i].X = samplesRatePerCount * i;

            }
                return points1;
        }

        public void StartListenToMicrophone() {

           // _inputData = new MicrophoneConnect(0, ((int)((double)BuffreSize / Rate * 1000.0)), new WaveFormat(Rate, 1));

            //_signalsBuffer = new InputSignalsBuffer(Rate, _inputData.InputSignal);

            _inputData.AddEventDataReader(_signalsBuffer);

            _inputData.StartRecording();
        }






        //public void ResizeYAxis(Point [] points, MindFusion.RealTimeCharting.Wpf.RealTimeChart _chart)
        //{
        //    if (points.Length!=0)
        //    {
        //        double val = points.Max(y => y.Y);
        //        _chart.YAxisCollection[0].Length = val;
        //        _chart.YAxisCollection[0].Interval = val / 5;
        //        _chart.Commit();
        //    }   
        //}
    }
}
