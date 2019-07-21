using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using XnaContent = Microsoft.Xna.Framework.Content;

namespace RpgeOpen.Core.Managers
{
    public sealed class FontManager : IManager
    {
        private readonly IDictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public void LoadContent(XnaContent.ContentManager content)
        {
            foreach(var file in Directory.GetFiles("Content/" + Constants.Paths.Fonts))
            {
                var fontName = Path.GetFileNameWithoutExtension(file);
                fonts.Add(
                    fontName.ToLower(), 
                    content.Load<SpriteFont>($"{Constants.Paths.Fonts}/{fontName}")
                );
            }
        }

        public SpriteFont this[string font]
        {
            get {
                font = font.ToLower();
                if (!fonts.ContainsKey(font))
                    throw new KeyNotFoundException("font not found");

                return fonts[font];
            }
        }
    }
}
