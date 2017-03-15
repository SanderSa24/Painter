using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class GameOverGameState : GameObjectList
    {
        private TextGameObject gameOver;
        private TextGameObject reStart;
        private bool play = false;
        public GameOverGameState() {
            gameOver = new TextGameObject("gameFont");
            gameOver.Position = new Vector2(96,192);
            reStart = new TextGameObject("gameFont");
            reStart.Position = new Vector2(96, 256);
            this.Add(gameOver);
            this.Add(reStart);
            gameOver.Text = "Game over dude! Game over!";
            reStart.Text = "Spacebar voor restart";
        }
        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.Space))
                play = true;
        }
        public override void Update(GameTime gameTime)
        {
            if (play) {

                Painter.GameStateManager.SwitchTo("playingState");
                play = false;
            }
            base.Update(gameTime);
        }
    }
}
