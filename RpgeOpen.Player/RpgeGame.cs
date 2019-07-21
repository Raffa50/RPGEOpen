using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;
using Newtonsoft.Json;
using RpgeOpen.Models.Entities;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Managers;
using RpgeOpen.Core.Binder.Python2;
using RpgeOpen.Core.Scenes;

namespace RpgeOpen.Player
{
    public class RpgeGame : Game, IRpgGame
    {
        private readonly GraphicsDeviceManager graphics;
        private IScriptBinder Python;
        
        public ViewportAdapter Viewport { get; private set; }

        public ProjectDetails GameData { get; private set; }

        public ContentManager ContentManager { get; }
        public SceneManager SceneManager { get; }
        public AudioManager AudioManager { get; }

        public FontManager FontManager { get; }

        public RpgeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ContentManager = new ContentManager(Content);
            SceneManager = new SceneManager(this);
            AudioManager = new AudioManager(Content);
            FontManager = new FontManager();
        }

        protected override void Initialize()
        {
            base.Initialize();

            Viewport = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);

            //python iterpreter
            try
            {
                Python = new PythonBinder();
                Python.Initialize(this);
            } catch (Exception ex)
            {
                SceneManager.Error(ex.Message + "\n" + ex.StackTrace);
            }
        }

        protected override void LoadContent()
        {
            FontManager.LoadContent(Content);

            if (File.Exists("Content/game.rpgeo"))
            {
                var content = File.ReadAllText("Content/game.rpgeo");
                GameData = JsonConvert.DeserializeObject<ProjectDetails>(content);
            }
            else
                SceneManager.Error("Project file not found in Content, game was not correctly buid");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            try
            {
                SceneManager.Update(gameTime);
            } catch(Exception ex)
            {
                SceneManager.Error(ex.Message+"\n"+ex.StackTrace);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            try
            {
                SceneManager.Draw(gameTime);
            } catch (Exception ex)
            {
                SceneManager.Error(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
