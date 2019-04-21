using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;
using MonoGame.Extended.Screens;

namespace RpgeOpen.Player.Scenes
{
    public abstract class AbstractScreen : Screen
    {
        protected AbstractScreen(Game1 game){
            Game = game;
        }

        public Game1 Game { get; }
        public ContentManager Content => Game.Content;
        public GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
        public Camera2D Camera => Game.Camera;
    }
}
