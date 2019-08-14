using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Core
{
    public abstract class AbstractGameObject : IGameObject
    {
        public ICollection<IGameObject> Children { get; } = new List<IGameObject>();

        public virtual void Dispose()
        {
            foreach (var c in Children)
                c.Dispose();
        }

        public virtual void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            foreach (var c in Children)
                c.Draw(time, spriteBatch);
        }

        public abstract void Initialize();

        public abstract void LoadContent(ContentManager Content);

        public virtual void Update(GameTime time)
        {
            foreach (var c in Children)
                c.Update(time);
        }
    }
}
