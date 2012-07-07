using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bank_Panic.Engine {


    class Target : Sprite {

        public override Vector2 direction {
            get { return speed; }
        }

        public Keys setKeyboardKey { 
            set { key = value; } 
        }

        public bool isShooting {
            get { return shoot; }
        }

        private Keys key = Keys.A;

        private bool shoot = false;
        
        public Target( Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed )
            : base( textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed )
        {
        }


        public Target( Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, bool animate, int millisecondsPerFrame )
            : base( textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, animate, millisecondsPerFrame )
        {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds) {

            if ( Keyboard.GetState().IsKeyDown( key ) ) {
                shoot = true;
            } else {
                shoot = false;
            }

            base.Update(gameTime, clientBounds);
        }

        public override Rectangle collisionRect
        {
            get
            {

                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    frameSize.X,
                    frameSize.Y);
            }
        }


    }
}
