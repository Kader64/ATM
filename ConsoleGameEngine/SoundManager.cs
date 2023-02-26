using System;
using NAudio;
using NAudio.Wave;

namespace ConsoleGameEngine
{
    public class SoundManager
    {
        public static SoundManager Music = new SoundManager();
        public static SoundManager SFX = new SoundManager();

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public void PlayLoop(string fileName, float volume = 1f)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
            }

            audioFile = new AudioFileReader(fileName);
            audioFile.Volume = volume;

            outputDevice = new WaveOutEvent();
            outputDevice.Init(new LoopStream(audioFile));
            outputDevice.Play();
        }

        public void Play(string fileName, float volume = 1f)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
            }

            audioFile = new AudioFileReader(fileName);
            audioFile.Volume = volume;

            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }

        public void Stop()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }
        }
    }
}
