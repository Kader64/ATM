using System;
using NAudio;
using NAudio.Wave;

namespace ConsoleGameEngine
{
    public class MusicManager
    {

        private WaveOutEvent outputDevice;

        public MusicManager(string path)
        {
            outputDevice = new WaveOutEvent();
            outputDevice.Init(new AudioFileReader(path));
        }

        public void Play()
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
