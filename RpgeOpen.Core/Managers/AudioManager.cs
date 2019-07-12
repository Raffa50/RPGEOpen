using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using RpgeOpen.Shared;
using System.IO;

namespace RpgeOpen.Core.Managers
{
    public sealed class AudioManager
    {
        private Song currentBgmSong;
        public string CurrentBgm { get; private set; }
        private readonly ContentManager Content;

        public AudioManager(ContentManager content)
        {
            Content = content;
        }

        public void PlayBgm(string name, float volume = 1f)
        {
            try
            {
                currentBgmSong = Content.Load<Song>($"{Constants.Paths.AudioBgm}/{name}");
            } catch(ContentLoadException ex)
            {
                throw new FileNotFoundException($"Audio file not found: {Constants.Paths.AudioBgm}/{name}", ex);
            }
            CurrentBgm = name;

            MediaPlayer.Volume = volume;
            MediaPlayer.Play(currentBgmSong);
        }

        public void FadeOutBgm(int seconds = 0)
        {
            if(seconds == 0)
            {
                MediaPlayer.Stop();
                return;
            }
        }
    }
}
