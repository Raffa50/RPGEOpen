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
using RpgeOpen.Core.SpriteSheets;
using RpgeOpen.Models;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Player.Scenes
{
    public class MapScene : AbstractScene {
        private SpriteBatch spriteBatch;
        private TiledMap renderMap;
        private Sprite player;
        private Texture2D playerSpriteSheet;

        public MapScene( IRpgGame game ) : base( game ) {}

        public override void Initialize() {
            var map = GameData.Maps.First();
            renderMap = new TiledMap( map );
        }

        public override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderMap.LoadContent( Content );

            playerSpriteSheet = Content.Load<Texture2D>( Path.Combine( Project.Paths.Characters, "player" ) );
            player = new Sprite(playerSpriteSheet, new Size(32, 32));
        }

        public override void UnloadContent() {
            renderMap.Dispose();
            playerSpriteSheet.Dispose();
        }

        public override void Update( GameTime time ) {
            var keyboardState = Keyboard.GetState();
            const float movementSpeed = 0.1f;
            var deltaTime = (float)time.ElapsedGameTime.TotalMilliseconds;

            player.IsMoving = false;
            if( keyboardState.IsKeyDown( Keys.Up ) ) {
                Camera.Position += new Vector2( 0, -movementSpeed * deltaTime );
                player.Direction = Direction.Up;
                player.IsMoving = true;
            } else if( keyboardState.IsKeyDown( Keys.Down ) ) {
                Camera.Position += new Vector2( 0, movementSpeed * deltaTime );
                player.Direction = Direction.Down;
                player.IsMoving = true;
            }

            if( keyboardState.IsKeyDown( Keys.Left ) ) {
                Camera.Position += new Vector2( -movementSpeed * deltaTime, 0 );
                player.Direction = Direction.Left;
                player.IsMoving = true;
            } else if( keyboardState.IsKeyDown( Keys.Right ) ) {
                Camera.Position += new Vector2( movementSpeed * deltaTime, 0 );
                player.Direction = Direction.Right;
                player.IsMoving = true;
            }

            player.Position = Camera.Position + new Vector2(400, 240);
            player.Update( time );
        }

        public override void Draw( GameTime time ) {
            spriteBatch.Begin(transformMatrix: Camera.CalculateTransformMatrix());
            renderMap.Draw( time, spriteBatch );
            player.Draw( time, spriteBatch );
            spriteBatch.End();
        }
    }
}
