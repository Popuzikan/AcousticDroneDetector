using AcusticDetector.Interfaces;
using NAudio.Wave;


namespace AcusticDetector.AnalogDataProvider
{
    public class InputSignalsBuffer : IMicConnected
    {
        public BufferedWaveProvider SignalProvider { get;  set; }
        public bool IsDeviceEnable { get; set; }

        public InputSignalsBuffer(int bufferLength, IWaveIn waveFormat)
        {
            SignalProvider = new BufferedWaveProvider(waveFormat?.WaveFormat);

            SignalProvider.BufferLength = bufferLength * 2;

            SignalProvider.DiscardOnBufferOverflow = true;

            IsDeviceEnable = true;
        }
        public void AudioDataAvailable(object sender, WaveInEventArgs e) => SignalProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
    }
}
