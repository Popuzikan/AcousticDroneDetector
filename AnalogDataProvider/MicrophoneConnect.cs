using System;
using System.Threading.Tasks;
using System.Windows;
using NAudio.Wave;

namespace AcusticDetector.AnalogDataProvider
{
    public class MicrophoneConnect : IDisposable
    {
        public IWaveIn InputSignal { get; internal set; }

        public MicrophoneConnect(int deviseNumber, int bufferMilisecond, WaveFormat waveFormat)
        {
            InputSignal = new WaveIn();

            var _inputSignals = InputSignal as WaveIn;

            _inputSignals.DeviceNumber = deviseNumber;

            _inputSignals.BufferMilliseconds = bufferMilisecond;

            InputSignal.WaveFormat = waveFormat != null ? waveFormat : new WaveFormat(44100, 1);

        }

        public void AddEventDataReader(InputSignalsBuffer buffer) => InputSignal.DataAvailable += buffer.AudioDataAvailable;

        public void StartRecording()
        {
            try
            {
                Task.Factory.StartNew(InputSignal.StartRecording);
            }
            catch 
            {
                string msg = "Не возможно сделать запись от аудио устройства! \n\n";
                msg += "Ваш микрофон включен?\n";
                msg += "Что установлено как ваше устройство записи по умолчанию?";
                MessageBox.Show(msg, "ERROR");
            }
        }

        public void Dispose()
        {
            InputSignal.Dispose();
        }
    }
}
