using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bank_Panic.Engine;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bank_Panic.Objects {

    class Door : Sprite {

        private int id;
        public bool boolIsDoorOpen = false;


        public int getId{
            get{
                return id;
            }
        }

        public int setId{
            set { 
                id = value; 
            }
        }

        public override Vector2 direction{
            get { 
                return speed; 
            }
        }

        public Door(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed) {
        }

        public Door(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, bool animate, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, animate, millisecondsPerFrame){
        }

        public override void Update( GameTime gameTime, Rectangle clientBounds ){
            // Move sprite based on direction
            if (boolIsDoorOpen){

            }
            //position += direction;
            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch){
            // Move sprite based on direction
            base.Draw(gameTime, spriteBatch);
        }
    }
}
