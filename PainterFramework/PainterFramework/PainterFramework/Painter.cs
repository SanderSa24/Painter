using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PainterFramework
{
  
    public class Painter : GameEnvironment
    {
        public Painter()
        {
       Content.RootDirectory = "Content";
       this.IsMouseVisible = true;
        }
        
        protected override void LoadContent()
        {
            base.LoadContent();

            
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Console.WriteLine("Loading content");
            gameStateManager.AddGameState("playingState",new PainterGameWorld());
            gameStateManager.AddGameState("GameOverState", new GameOverGameState());
            gameStateManager.SwitchTo("playingState");
            AssetManager.PlayMusic("snd_music");
        }

    
    }
}
