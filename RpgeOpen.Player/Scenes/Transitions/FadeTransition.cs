using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Player.Scenes.Transitions
{
    public class FadeTransition : Transition
    {
        public FadeTransition(int time) : base(time) { }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
