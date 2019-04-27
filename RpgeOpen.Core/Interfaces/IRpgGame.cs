using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Core.Interfaces
{
    public interface IRpgGame
    {
        ContentManager Content { get; }
        GraphicsDevice GraphicsDevice { get; }
        ViewportAdapter Viewport { get; }
        Project GameData { get; }
        ScreenManager SceneManager { get; }
    }
}
