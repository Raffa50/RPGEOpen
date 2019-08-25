using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Core.Managers;

namespace RpgeOpen.Core.Scenes
{
    public class ErrorScene : AbstractScene
    {
        private readonly string ErrorMsg;
        private readonly FontManager FontManager;

        public ErrorScene(IRpgGame game, string errorMsg) : base(game) {
            ErrorMsg = errorMsg;
            FontManager = game.FontManager;
        }

        public override void Initialize()
        {
            base.Initialize();
            UserInterface.Active.Clear();
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(FontManager["arial"], "ERROR", new Vector2(Game.GraphicsDevice.Viewport.Width / 2, 70), Color.Red);
            spriteBatch.DrawString(FontManager["palatino"], ErrorMsg, new Vector2(10, 150), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();
        }
    }
}
