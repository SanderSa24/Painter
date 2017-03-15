using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PainterFramework
{
    class ThreeColorGameObject : RotatableSpriteGameObject
    {
        protected SpriteSheet colorRedSprite, colorGreenSprite, colorBlueSprite;
        protected Color color;
        public ThreeColorGameObject(string redAssetName, string greenAssetName, string blueAssetName) : base("") {

            colorRedSprite = new SpriteSheet(redAssetName);
            colorGreenSprite = new SpriteSheet(greenAssetName);
            colorBlueSprite = new SpriteSheet(blueAssetName);
            color = Color.Blue;
        }
        public override void Reset()
        {

            base.Reset();
            color = Color.Blue;

        }
        public Color Color
        {
            get { return color; }
            set
            {
                if (value != Color.Red && value != Color.Green && value != Color.Blue)
                    return;
                color = value;
                if (Color == Color.Red)
                    sprite = colorRedSprite;
                else if (Color == Color.Green)
                    sprite = colorGreenSprite;
                else if (Color == Color.Blue)
                    sprite = colorBlueSprite;
            }
        }
    }
}
