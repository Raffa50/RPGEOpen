using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;
using RpgeOpen.Core.Managers;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Core.Interfaces
{
    public interface IRpgGame
    {
        ContentManager ContentManager { get; }
        GraphicsDevice GraphicsDevice { get; }
        ViewportAdapter Viewport { get; }
        ProjectDetails GameData { get; }

        SceneManager SceneManager { get; }
        AudioManager AudioManager { get; }
        FontManager FontManager { get; }

        void Exit();
    }
}
