using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Scenes;
using System;

namespace RpgeOpen.Core.Managers
{
    public sealed class SceneManager : IManager
    {
        private readonly ScreenManager manager;
        private readonly IRpgGame game;

        public SceneManager(IRpgGame game)
        {
            manager = new ScreenManager();
            this.game = game;
        }

        public void GoTo(AbstractScene scene, Transition transition = null)
        {
            try
            {
                if (transition == null)
                    manager.LoadScreen(scene);
                else
                    manager.LoadScreen(scene, transition);
            }
            catch (Exception ex)
            {
                manager.LoadScreen(new ErrorScene(game, ex.Message + "\n" + ex.StackTrace));
            }
        }

        public void Update(GameTime gameTime)
        {
            manager.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            manager.Draw(gameTime);
        }

        public void Initialize()
        {
            manager.Initialize();
        }
    }
}
