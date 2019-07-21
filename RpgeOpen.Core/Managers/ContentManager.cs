using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using System;
using XnaContent = Microsoft.Xna.Framework.Content;

namespace RpgeOpen.Core.Managers
{
    public sealed class ContentManager : XnaContent.ContentManager, IManager
    {
        public ContentManager(XnaContent.ContentManager content)
            :base(content.ServiceProvider, content.RootDirectory)
        {
        }

        public Texture2D LoadImage(string name)
        {
            return Load<Texture2D>(name);
        }
    }
}
