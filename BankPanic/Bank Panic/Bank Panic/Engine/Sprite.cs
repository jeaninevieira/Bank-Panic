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

namespace Bank_Panic.Engine {

    abstract class Sprite {

    	// Stuff needed to draw the sprite
        Texture2D textureImage;
        protected Point frameSize;
        Point currentFrame;
        Point sheetSize;

        protected bool animate;
        const bool defaultAnimate = false;

        // Collision data
        int collisionOffset;
        
        // Framerate stuff
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;

        // Movement data
        protected Vector2 speed;
        protected Vector2 position;

        // Abstract definition of direction property
        public abstract Vector2 direction {
            get;
        }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
    int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : this(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, defaultAnimate, defaultMillisecondsPerFrame)
        {
        }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
            bool animate, int millisecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.animate = animate;
            this.millisecondsPerFrame = millisecondsPerFrame;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {

            if (animate)
            {
                // Update frame if time to do so based on framerate
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    // Increment to next frame
                    timeSinceLastFrame = 0;
                    ++currentFrame.X;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 0;
                        ++currentFrame.Y;
                        if (currentFrame.Y >= sheetSize.Y)
                            currentFrame.Y = 0;
                    }
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Draw(textureImage,
                position,
                new Rectangle(currentFrame.X * frameSize.X,
                    currentFrame.Y * frameSize.Y,
                    frameSize.X, frameSize.Y),
                Color.White, 0, Vector2.Zero,
                1f, SpriteEffects.None, 0);
        }

        // Gets the collision rect based on position, framesize and collision offset
        public virtual Rectangle collisionRect
        {
            get
            {

                //    Console.WriteLine( "Matrix" );
                //    Console.WriteLine( Vector2.Transform(position, Matrix.Invert(Camera.WorldMovement())));

                Vector2 transformedPosition = Vector2.Transform(position, Camera.WorldMovement());

                //    Console.WriteLine( transformedPosition.X );
                //    Console.WriteLine( position.X );

                return new Rectangle(
                    (int)transformedPosition.X + collisionOffset,
                    (int)transformedPosition.Y + collisionOffset,
                    frameSize.X - (collisionOffset * 2),
                    frameSize.Y - (collisionOffset * 2));

            }
        }

    }

}
