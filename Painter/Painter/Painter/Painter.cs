using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Painter
{
    public class Painter : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static GameWorld gameWorld;
        InputHelper inputHelper;
        static Random random;
        static Point screen;

        
        public Painter():base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            inputHelper = new InputHelper();
            IsMouseVisible = true;
            random = new Random();
        }

        public static GameWorld GameWorld
        {
            get { return gameWorld; }
        }

        public static Random Random
        {
            get { return random; }
        }
        public static Point Screen
        {
            get { return screen; }
        }
        
        protected override void Initialize()
        {
 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameWorld = new GameWorld(this.Content);

            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Content.Load<Song>("snd_music"));

        }


        protected override void UnloadContent()
        {
        }
        
          

protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            inputHelper.Update();
            gameWorld.HandleInput(inputHelper);
            gameWorld.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            gameWorld.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
