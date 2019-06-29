using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Shared
{
    public static class Constants
    {
        public static class Extensions
        {
            public static readonly IEnumerable<string> Images = new[] { ".jpg", ".png", ".jpeg", ".bmp" };
            public static readonly IEnumerable<string> Audios = new[] { ".mp3", ".ogg" };
        }
        public static class Paths
        {
            public const string
                TileSheets = "TileSheets",
                Maps = "Maps",
                Characters = "Characters",
                Backgrounds = "Backgrounds",
                AudioBgm = "Audio/Bgm",
                Scripts = "Scripts",
                Fonts = "Fonts";
        }
    }
}
