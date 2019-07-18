using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;

namespace RpgeOpen.Core.Scenes
{
    public class BattleScene : AbstractScene
    {
        public BattleScene(IRpgGame game)
            : base(game) { }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
