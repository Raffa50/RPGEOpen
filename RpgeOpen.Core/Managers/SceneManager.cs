using GeonBit.UI;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Scenes;
using RpgeOpen.Shared.Tracing;
using System;

namespace RpgeOpen.Core.Managers
{
    public sealed class SceneManager : IManager
    {
        private readonly ScreenManager manager;
        private readonly IRpgGame game;
        private readonly ITracer tracer;
        private AbstractScene currentScene;
        public Type PreviousScene { get; private set; }

        public SceneManager(IRpgGame game)
        {
            manager = new ScreenManager();
            this.game = game;
            tracer = game.Tracer;
        }

        public void GoTo(AbstractScene scene, Transition transition = null)
        {
            UserInterface.Active.Clear();
            try
            {
                if (transition == null)
                    manager.LoadScreen(scene);
                else
                    manager.LoadScreen(scene, transition);

                PreviousScene = currentScene?.GetType();
                currentScene = scene;
            }
            catch (Exception ex)
            {
                tracer.Critical("unhandled exception", exception: ex);
                if(!(currentScene is ErrorScene))
                    manager.LoadScreen(new ErrorScene(game, ex.Message + "\n" + ex.StackTrace));
            }
        }

        public void Back(Transition transition = null)
        {
            var scene = (AbstractScene)Activator.CreateInstance(PreviousScene, game);
            GoTo(scene, transition);
        }

        public void Error(string errorMsg)
        {
            GoTo(new ErrorScene(game, errorMsg));
        }

        public void Update(GameTime gameTime)
        {
            try
            {
                manager.Update(gameTime);
            }catch(Exception ex)
            {
                tracer.Critical("unhandled exception", exception: ex);
                if (!(currentScene is ErrorScene))
                    manager.LoadScreen(new ErrorScene(game, ex.Message + "\n" + ex.StackTrace));
            }
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
