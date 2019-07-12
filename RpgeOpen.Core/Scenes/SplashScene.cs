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
        private SpriteBatch spriteBatch;
        private Texture2D bg;
        private TimeSpan? initial;

        public SplashScene(IRpgGame game): base(game) { }

        public override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bg = Content.Load<Texture2D>( "Backgrounds/rpge" );

            Game.AudioManager.PlayBgm("bgm");
        }

        public override void UnloadContent() {
            bg.Dispose();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bg, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime) {
            if( initial == null )
                initial = gameTime.TotalGameTime;

            if(gameTime.TotalGameTime -initial > TimeSpan.FromSeconds( 3 ) && !changeScreen ) {
                SceneManager.GoTo( new MapScene(Game), new FadeTransition( GraphicsDevice, Color.Black, 2 ) );
                changeScreen = true;
            }
        }
    }
}
