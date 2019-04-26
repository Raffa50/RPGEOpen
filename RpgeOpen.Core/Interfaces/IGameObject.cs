using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RpgeOpen.Core.Interfaces
{
    public interface IGameObject : IDisposable
    {
        void Initialize();
        void LoadContent( ContentManager Content );
        void Draw( GameTime time, SpriteBatch spriteBatch);
        void Update( GameTime time );
    }
}
