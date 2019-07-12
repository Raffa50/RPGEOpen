using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Shared;
using System.IO;
using XnaContent = Microsoft.Xna.Framework.Content;

namespace RpgeOpen.Core.Managers
{
    public sealed class AudioManager: IManager
    {
        private Song currentBgmSong;
        public string CurrentBgm { get; private set; }
        private readonly XnaContent.ContentManager Content;

        public AudioManager(XnaContent.ContentManager content)
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
