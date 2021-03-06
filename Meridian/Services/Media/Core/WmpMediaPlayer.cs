﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Meridian.Model;
using Meridian.ViewModel.Messages;

namespace Meridian.Services.Media.Core
{
    /// <summary>
    /// Wrapper on MediaElement which uses Windows Media Player engine
    /// </summary>
    public class WmpMediaPlayer : MediaPlayerBase
    {
        private MediaPlayer _mediaPlayer;

        public override TimeSpan Position
        {
            get { return _mediaPlayer.Position; }
            set { _mediaPlayer.Position = value; }
        }

        public override TimeSpan Duration
        {
            get
            {
                if (_mediaPlayer.NaturalDuration != null && _mediaPlayer.NaturalDuration.HasTimeSpan)
                    return _mediaPlayer.NaturalDuration.TimeSpan;

                return TimeSpan.Zero;
            }
        }

        public override Uri Source
        {
            get { return _mediaPlayer.Source; }
            set { _mediaPlayer.Open(value); }
        }

        public override double Volume
        {
            get { return _mediaPlayer.Volume; }
            set { _mediaPlayer.Volume = value; }
        }

        public override void Initialize()
        {
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.MediaEnded  += MediaPlayerOnMediaEnded;
            _mediaPlayer.MediaFailed += MediaPlayerOnMediaFailed;
            _mediaPlayer.MediaOpened += MediaPlayerOnMediaOpened;
        }

        public override void Play()
        {
            _mediaPlayer.Play();
        }

        public override void Pause()
        {
            _mediaPlayer.Pause();
        }

        public override void Stop()
        {
            _mediaPlayer.Stop();
        }

        public override void Dispose()
        {
            _mediaPlayer.MediaEnded -= MediaPlayerOnMediaEnded;
            _mediaPlayer.MediaFailed -= MediaPlayerOnMediaFailed;
            _mediaPlayer.MediaOpened -= MediaPlayerOnMediaOpened;

            _mediaPlayer = null;
        }

        private void MediaPlayerOnMediaOpened(object sender, EventArgs e)
        {
            if (MediaOpened != null)
                MediaOpened(sender, e);
        }

        private void MediaPlayerOnMediaFailed(object sender, ExceptionEventArgs e)
        {
            if (MediaFailed != null)
                MediaFailed(sender, e.ErrorException);
        }

        private void MediaPlayerOnMediaEnded(object sender, EventArgs e)
        {
            if (MediaEnded != null)
                MediaEnded(sender, e);
        }
    }
}
