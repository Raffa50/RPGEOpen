using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RpgeOpen.Player.Objects
{
    public interface IGameObject : IDisposable
    {
        void Initialize();
        void LoadContent( ContentManager Content );
        void Draw( GameTime time );
        void Update( GameTime time );
    }
}
