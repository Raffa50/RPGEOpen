using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Shared;
using System;
using XnaContent = Microsoft.Xna.Framework.Content;

namespace RpgeOpen.Core.Managers
{
    public sealed class ContentManager : XnaContent.ContentManager
    {
        public ContentManager(XnaContent.ContentManager content)
            :base(content.ServiceProvider, content.RootDirectory)
        {
        }

        public Texture2D LoadImage(string name)
        {
            return Load<Texture2D>(name);
        }

        [Obsolete("Font manager not implemented yet")]
        public SpriteFont LoadFont(string name)
        {
            return Load<SpriteFont>($"{Constants.Paths.Fonts}/{name}");
        }
    }
}
