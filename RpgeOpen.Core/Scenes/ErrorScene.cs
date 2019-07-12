using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Shared;

namespace RpgeOpen.Core.Scenes
{
    public class ErrorScene : AbstractScene
    {
        private readonly string ErrorMsg;
        private SpriteBatch spriteBatch;
        private SpriteFont arial, helvetica;

        public ErrorScene(IRpgGame game, string errorMsg) : base(game) {
            ErrorMsg = errorMsg;
        }

        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arial = ContentManager.LoadFont("Arial");
            helvetica = ContentManager.LoadFont("Palatino");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(helvetica, "ERROR", new Vector2(GraphicsDevice.Viewport.Width / 2, 70), Color.Red);
            spriteBatch.DrawString(arial, ErrorMsg, new Vector2(10, 150), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();
        }
    }
}
