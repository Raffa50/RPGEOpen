using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RpgeOpen.Player.Objects
{
    public abstract class AbstractGameObject
    {
        public Vector2 Position { get; set; } = Vector2.Zero;

        public virtual void LoadContent(ContentManager Content) {}
        public virtual void Draw( GameTime gameTime ) {}
        public virtual void Initialize() {}
    }
}
