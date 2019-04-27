using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using System.IO;

using Newtonsoft.Json;

using RpgeOpen.Models.Entities;
using RpgeOpen.Player.Scenes;
using RpgeOpen.Core;
using RpgeOpen.Core.Interfaces;

namespace RpgeOpen.Player
{
    public class RpgeGame : Game, IRpgGame
    {
        private readonly GraphicsDeviceManager graphics;
        //private SpriteBatch spriteBatch;
        public Project GameData { get; private set; }

        public ViewportAdapter Viewport { get; private set; }
        public ScreenManager SceneManager { get; }

        public RpgeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            SceneManager = new ScreenManager();
        }

        protected override void Initialize()
        {
            base.Initialize();

            Viewport = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);

            Components.Add(SceneManager);
            SceneManager.LoadScreen(new SplashScene(this));
        }

        protected override void LoadContent()
        {
            if (File.Exists("Content/game.rpgeo"))
            {
                var content = File.ReadAllText("Content/game.rpgeo");
                GameData = JsonConvert.DeserializeObject<Project>(content);
            }
            else Debug.WriteLine("Project file not found");
        }

        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            SceneManager.Update( gameTime );
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SceneManager.Draw(gameTime);
        }
    }
}
