using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using RpgeOpen.Core.Managers;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Core.Interfaces
{
    public interface IRpgGame
    {
        ContentManager Content { get; }
        GraphicsDevice GraphicsDevice { get; }
        ViewportAdapter Viewport { get; }
        ProjectDetails GameData { get; }

        ScreenManager SceneManager { get; }
        AudioManager AudioManager { get; }

        void Exit();
    }
}
