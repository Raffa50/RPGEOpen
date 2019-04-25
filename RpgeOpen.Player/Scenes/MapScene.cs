using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RpgeOpen.Player.Scenes
{
    public class MapScene : AbstractScreen {
        private SpriteBatch spriteBatch;
        private Texture2D test;

        public MapScene( RpgeGame game ) : base( game ) {}

        public override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //using (var fileStream = new FileStream("Content/TileSheets/magecity.png", FileMode.Open))
            //{
            //    test = Texture2D.FromStream(GraphicsDevice, fileStream);
            //}
            test = Content.Load<Texture2D>( "TileSheets/magecity" );
        }

        public override void Update( GameTime time ) {
            var keyboardState = Keyboard.GetState();
            const float movementSpeed = 0.2f;
            var deltaTime = (float)time.ElapsedGameTime.TotalMilliseconds;

            if (keyboardState.IsKeyDown(Keys.Up))
                Camera.Move(new Vector2(0, -movementSpeed * deltaTime));
            if (keyboardState.IsKeyDown(Keys.Down))
                Camera.Move(new Vector2(0, movementSpeed * deltaTime));
            if (keyboardState.IsKeyDown(Keys.Left))
                Camera.Move(new Vector2(-movementSpeed * deltaTime, 0));
            if (keyboardState.IsKeyDown(Keys.Right))
                Camera.Move(new Vector2(movementSpeed * deltaTime, 0));

            base.Update(time);
        }

        public override void Draw( GameTime time ) {
            spriteBatch.Begin(transformMatrix: Camera.GetViewMatrix());
            spriteBatch.Draw(test, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(time);
        }
    }
}
