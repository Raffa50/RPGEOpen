using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Core.Scenes
{
    public class TitleScene : AbstractScene
    {
        protected Button BtnNewGame;
        private bool transition;

        public TitleScene(IRpgGame game) : base(game) { }

        public override void Initialize()
        {
            var panel = new Panel(new Vector2(400, 400), PanelSkin.Default, Anchor.Center);
            UserInterface.Active.AddEntity(panel);

            // add title and text
            panel.AddChild(new Header("Rpge Open"));

            // add a button at the bottom
            BtnNewGame = new Button("New Game", ButtonSkin.Default, Anchor.BottomCenter);
            BtnNewGame.OnClick += s => {
                if (transition)
                    return;
                transition = true;
                SceneManager.GoTo(new MapScene(Game));
            };
            panel.AddChild(BtnNewGame);
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
