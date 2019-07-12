using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Core.Scenes
{
    public class TitleScene : AbstractScene
    {
        public TitleScene(IRpgGame game) : base(game) { }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
