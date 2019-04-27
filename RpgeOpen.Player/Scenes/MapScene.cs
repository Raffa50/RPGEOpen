using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgeOpen.Core;
using RpgeOpen.Core.Interfaces;

namespace RpgeOpen.Player.Scenes
{
    public class MapScene : AbstractScene {
        private SpriteBatch spriteBatch;
        private TiledMap renderMap;

        public MapScene( IRpgGame game ) : base( game ) {}

        public override void Initialize() {
            var map = GameData.Maps.First();
            renderMap = new TiledMap( map );
        }

        public override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderMap.LoadContent( Content );
        }

        public override void Update( GameTime time ) {
            var keyboardState = Keyboard.GetState();
            const float movementSpeed = 0.2f;
            var deltaTime = (float)time.ElapsedGameTime.TotalMilliseconds;

            if (keyboardState.IsKeyDown(Keys.Up))
                Camera.Position += new Vector2(0, -movementSpeed * deltaTime);
            if (keyboardState.IsKeyDown(Keys.Down))
                Camera.Position += new Vector2(0, movementSpeed * deltaTime);
            if (keyboardState.IsKeyDown(Keys.Left))
                Camera.Position += new Vector2(-movementSpeed * deltaTime, 0);
            if (keyboardState.IsKeyDown(Keys.Right))
                Camera.Position += new Vector2(movementSpeed * deltaTime, 0);
        }

        public override void Draw( GameTime time ) {
            spriteBatch.Begin(transformMatrix: Camera.CalculateTransformMatrix());
            renderMap.Draw( time, spriteBatch );
            spriteBatch.End();
        }
    }
}
