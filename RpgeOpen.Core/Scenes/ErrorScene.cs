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
        private SpriteFont arial, helvetica;

        public ErrorScene(IRpgGame game, string errorMsg) : base(game) {
            ErrorMsg = errorMsg;
        }

        public override void LoadContent()
        {
            arial = ContentManager.LoadFont("Arial");
            helvetica = ContentManager.LoadFont("Palatino");
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(helvetica, "ERROR", new Vector2(Game.GraphicsDevice.Viewport.Width / 2, 70), Color.Red);
            spriteBatch.DrawString(arial, ErrorMsg, new Vector2(10, 150), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();
        }
    }
}
