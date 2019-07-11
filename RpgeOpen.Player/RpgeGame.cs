using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using Newtonsoft.Json;
using RpgeOpen.Models.Entities;
using RpgeOpen.Player.Scenes;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Managers;
using RpgeOpen.Shared;
using RpgeOpen.Core;
using System.Reflection;
using RpgeOpen.Core.Binder.Python2;

namespace RpgeOpen.Player
{
    public class RpgeGame : Game, IRpgGame
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly PythonBinder Python = new PythonBinder();
        
        public ViewportAdapter Viewport { get; private set; }

        public ProjectDetails GameData { get; private set; }
        public ScreenManager SceneManager { get; }
        public AudioManager AudioManager { get; }

        public RpgeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            SceneManager = new ScreenManager();
            AudioManager = new AudioManager(Content);
        }

        protected override void Initialize()
        {
            base.Initialize();

            Viewport = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);

            //python iterpreter
            Python.Initialize(this);
            var SplashScene = Python.GetVariable("SplashScene")(this);

            Components.Add(SceneManager);
            try
            {
                SceneManager.LoadScreen(SplashScene);
            }
            catch (Exception ex)
            {
                SceneManager.LoadScreen(new ErrorScene(this, ex.Message+"\n"+ex.StackTrace));
            }
        }

        protected override void LoadContent()
        {
            if (File.Exists("Content/game.rpgeo"))
            {
                var content = File.ReadAllText("Content/game.rpgeo");
                GameData = JsonConvert.DeserializeObject<ProjectDetails>(content);
            }
            else Debug.WriteLine("Project file not found");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
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
