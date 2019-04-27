using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;

using RpgeOpen.Core.Interfaces;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Core
{
    public abstract class AbstractScene : Screen
    {
        protected AbstractScene(IRpgGame game){
            Game = game;
        }

        public IRpgGame Game { get; }
        public ContentManager Content => Game.Content;
        public GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
        public Project GameData => Game.GameData;
        public ScreenManager SceneManager => Game.SceneManager;
        public ViewportAdapter Viewport => Game.Viewport;
    }
}
