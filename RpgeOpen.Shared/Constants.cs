using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RpgeOpen.Shared
{
    public static class Constants
    {
        public static readonly Regex VariableNameRegex = new Regex("^[a-zA-Z_][a-zA-Z0-9_]*$", RegexOptions.Compiled);

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
