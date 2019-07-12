using Microsoft.Xna.Framework.Content;
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
        protected AbstractScene(IRpgGame game){
            Game = game;
        }

        public IRpgGame Game { get; }
        public ContentManager Content => Game.Content;
        public GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
        public ProjectDetails GameData => Game.GameData;
        public SceneManager SceneManager => Game.SceneManager;
        public ViewportAdapter Viewport => Game.Viewport;
    }
}
