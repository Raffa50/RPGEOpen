using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;

using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Managers;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Core.Scenes
{
    public abstract class AbstractScene : Screen
    {
        public IRpgGame Game { get; }
        private readonly SpriteBatch SpriteBatch;
        protected Camera2D Camera { get; private set; }

        protected AbstractScene(IRpgGame game){
            Game = game;
            SpriteBatch = new SpriteBatch(Game.GraphicsDevice);
            Camera = new Camera2D(Viewport) { Origin = Vector2.Zero };
        }

        public ContentManager ContentManager => Game.ContentManager;
        public ProjectDetails GameData => Game.GameData;
        public SceneManager SceneManager => Game.SceneManager;
        public ViewportAdapter Viewport => Game.Viewport;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override sealed void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin(transformMatrix: Camera.CalculateTransformMatrix());
            Draw(gameTime, SpriteBatch);
            SpriteBatch.End();
            UserInterface.Active.Draw(SpriteBatch);
        }

        protected abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
