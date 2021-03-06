﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Maps;
using RpgeOpen.Core.Sprites;
using RpgeOpen.Models;
using RpgeOpen.Shared;

namespace RpgeOpen.Core.Scenes
{
    public class MapScene : AbstractScene {
        private TiledMap renderMap;
        protected Entity MenuMain;
        private bool EscReleased = true;
        private SpriteCharacter player;
        private Texture2D playerSpriteSheet;

        private Size MapSize => renderMap.Size;

        public MapScene( IRpgGame game ) : base( game ) {}

        public override void Initialize() {
            base.Initialize();

            var map = GameData.Maps.First();
            renderMap = new TiledMap( map );

            MenuMain = new Panel(new Vector2(200, 400), PanelSkin.Default, Anchor.BottomRight);
            var btn = new Button("Test", ButtonSkin.Default, Anchor.TopCenter);
            MenuMain.AddChild(btn, true);
            MenuMain.Visible = false;
            UserInterface.Active.AddEntity(MenuMain);
        }

        public override void LoadContent() {
            renderMap.LoadContent( ContentManager );

            playerSpriteSheet = ContentManager.Load<Texture2D>( Path.Combine( Constants.Paths.Characters, "player" ) );
            player = new SpriteCharacter( playerSpriteSheet, new Size( 32, 32 ) ) {
                Position = new Point( renderMap.Size.Width /2, renderMap.Size.Height /2 )
            };
        }

        public override void UnloadContent() {
            renderMap.Dispose();
            playerSpriteSheet.Dispose();
        }

        private PassabilityType playerIntersectObstacle()
        {
            foreach (var block in renderMap.Blocks.Values)
                if (player.Box.Intersects(block.Box))
                    return block.Passability;

            return PassabilityType.Allow;
        }

        public override void Update( GameTime time ) {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyUp(Keys.Escape) && !EscReleased)
                EscReleased = true;
            if (keyboardState.IsKeyDown(Keys.Escape) && EscReleased)
            {
                EscReleased = false;
                MenuMain.Visible = !MenuMain.Visible;
            }
            if (MenuMain.Visible)
                return;

            const float movementSpeed = 0.07f;
            var deltaTime = (float)time.ElapsedGameTime.TotalMilliseconds;

            var initialPosition = player.Position;
            player.IsMoving = false;

            if( keyboardState.IsKeyDown( Keys.Up ) && player.CornerLeft.Y > 0 ) {
                player.Position += new Vector2( 0, -movementSpeed * deltaTime ).ToPoint();
                player.Direction = Direction.Up;
                player.IsMoving = true;
            } else if( keyboardState.IsKeyDown( Keys.Down ) && player.CornerLeft.Y + player.Size.Height < MapSize.Height) {
                player.Position += new Vector2( 0, movementSpeed * deltaTime ).ToPoint();
                player.Direction = Direction.Down;
                player.IsMoving = true;
            }

            if( keyboardState.IsKeyDown( Keys.Left ) && player.CornerLeft.X > 0 ) {
                player.Position += new Vector2( -movementSpeed * deltaTime, 0 ).ToPoint();
                player.Direction = Direction.Left;
                player.IsMoving = true;
            } else if( keyboardState.IsKeyDown( Keys.Right ) && player.CornerLeft.X + player.Size.Width < MapSize.Width ) {
                player.Position += new Vector2( movementSpeed * deltaTime, 0 ).ToPoint();
                player.Direction = Direction.Right;
                player.IsMoving = true;
            }

            if (playerIntersectObstacle() != PassabilityType.Allow)
                player.Position = initialPosition;

            Camera.Position = (player.Position -new Point(Viewport.ViewportWidth /2, Viewport.ViewportHeight /2)).ToVector2();
            player.Update( time );
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            renderMap.Draw(gameTime, spriteBatch );
            player.Draw(gameTime, spriteBatch );
        }
    }
}
