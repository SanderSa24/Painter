using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PainterFramework
{
    class PainterGameWorld : GameObjectList
    {
        private SpriteGameObject background = null, sgo, scoreBar;
        private TextGameObject scoreText;
        private RotatableSpriteGameObject cannonBarrel = null;
        private ThreeColorGameObject cannonColor = null;
        private ThreeColorGameObject can1 = null, can2 = null,  can3 = null;
        private int score, lives, maxLives;
        private GameObjectList livesSprites;
        private Ball ball;

        public PainterGameWorld() {
            background = new SpriteGameObject("spr_background");
            scoreBar = new SpriteGameObject("spr_scorebar");
            // sgo = new SpriteGameObject("spr_lives");
            cannonBarrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannonBarrel.Position = new Vector2(74,404);
            cannonBarrel.Origin = new Vector2(34, 34);
            cannonColor = new ThreeColorGameObject("spr_cannon_red","spr_cannon_green","spr_cannon_blue");
            cannonColor.Position = new Vector2(52,398);

            ball = new Ball();
            can1 = new PaintCan(450f, Color.Red);
            can2 = new PaintCan(575f,Color.Green);
            can3 = new PaintCan(700f, Color.Blue);
            scoreText = new TextGameObject("GameFont");
            scoreText.Position = new Vector2(8,8);
            livesSprites = new GameObjectList();
            livesSprites.Position = new Vector2(0,16);
            
            this.Add(background);
            this.Add(cannonBarrel);
            this.Add(cannonColor);
            this.Add(can1);
            this.Add(can2);
            this.Add(can3);
            this.Add(ball);
            this.Score = 0;
            this.lives = 5;
            this.Add(scoreBar);
           // this.Add(sgo);
            this.maxLives = lives;
            this.Add(scoreText);
            this.Add(livesSprites);
            cannonColor.Color = Color.Blue;
            for (int lifeNr = 0; lifeNr < maxLives; lifeNr++)
            {
                SpriteGameObject life = new SpriteGameObject("spr_lives", 0, lifeNr.ToString());
                life.Position = new Vector2(lifeNr * life.BoundingBox.Width, 30);
                livesSprites.Add(life);
            }

        }
           public override void Update(GameTime gameTime) {
            if (ball.CollidesWith(can1)) {
                can1.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(can2))
            {
                can2.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(can3))
            {
                can3.Color = ball.Color;
                ball.Reset();
            }
            if (lives <=0) {
                Painter.GameStateManager.SwitchTo("GameOverState");
                lives = 5;
                livesSprites.Reset();
                Score = 0;
                
            }
            base.Update(gameTime);
        }
        public int Score {
            get { return score; }
            set { score = value;
                if (scoreText != null)
                    scoreText.Text = "Score:" + value;
            }
        }
        public int Lives {
            get { return lives; }
            set {
                if (value > maxLives)
                    return;

                for (int lifeNr = 0; lifeNr < maxLives; lifeNr++) {
                    SpriteGameObject sgo = (SpriteGameObject)livesSprites.Find(lifeNr.ToString());
                    sgo.Visible = (lifeNr < value);
                }
                lives = value;
            }
        }
        public bool IsOutsideWorld(Vector2 aPosition) {
            return aPosition.X < 0 || aPosition.X > Painter.Screen.X || aPosition.Y > Painter.Screen.Y;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.R))
                cannonColor.Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G))
                cannonColor.Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B))
                cannonColor.Color = Color.Blue;
            double opposite = inputHelper.MousePosition.Y - cannonBarrel.GlobalPosition.Y;
            double adjacent = inputHelper.MousePosition.X - cannonBarrel.GlobalPosition.X;
            cannonBarrel.Angle = (float)Math.Atan2(opposite,adjacent);
            if (inputHelper.MouseLeftButtonPressed() && !ball.Shooting) {
                ball.Shoot(inputHelper, cannonColor, cannonBarrel);
            }
        }
     
    }
}
