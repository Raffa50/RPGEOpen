using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Screens.Transitions;
using RpgeOpen.Core.Interfaces;

namespace RpgeOpen.Core.Scenes
{
    public class SplashScene : AbstractScene {
        private bool changeScreen;
        private Texture2D bg;
        private TimeSpan? initial;

        public SplashScene(IRpgGame game): base(game) { }

        public override void LoadContent() {
            bg = ContentManager.Load<Texture2D>( "Backgrounds/rpge" );

            Game.AudioManager.PlayBgm("bgm");
        }

        public override void UnloadContent() {
            bg.Dispose();
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, Vector2.Zero, Color.White);
        }

        public override void Update(GameTime gameTime) {
            if( initial == null )
                initial = gameTime.TotalGameTime;

            if(gameTime.TotalGameTime -initial > TimeSpan.FromSeconds( 3 ) && !changeScreen ) {
                SceneManager.GoTo( new MapScene(Game), new FadeTransition( Game.GraphicsDevice, Color.Black, 2 ) );
                changeScreen = true;
            }
        }
    }
}
