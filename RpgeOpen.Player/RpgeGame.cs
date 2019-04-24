using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using System.IO;
using System.Runtime.CompilerServices;

using RpgeOpen.Player.Scenes;

namespace RpgeOpen.Player
{
    public class RpgeGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        //private SpriteBatch spriteBatch;

        public Camera2D Camera { get; private set; }
        public ScreenGameComponent SceneManager { get; }

        public RpgeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            SceneManager = new ScreenGameComponent(this);
            SceneManager.Register(new MapScene(this));
            Components.Add(SceneManager);
        }

        protected override void Initialize()
        {
            base.Initialize();

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);
            Camera = new Camera2D(viewportAdapter);

            SceneManager.Initialize();
        }

        protected override void LoadContent()
        {
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
