using System;
using NAudio;
using NAudio.Wave;

namespace ConsoleGameEngine
{
    public class MusicManager
    {

        private WaveOutEvent outputDevice;
        private LoopingWaveStream loopingStream;

        public MusicManager(string path)
        {
            outputDevice = new WaveOutEvent();
            loopingStream = new LoopingWaveStream(new AudioFileReader(path));
            outputDevice.Init(loopingStream);
        }


        public void PlayLoop()
        {
            Thread musicThread = new Thread(() =>
            {
                outputDevice.Play();
            });
            musicThread.Start();
        }
        public void Stop()
        {
            outputDevice.Stop();
        }
        public void setVolume(float volume)
        {
            outputDevice.Volume = volume;
        }
    }
}
