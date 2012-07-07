using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bank_Panic.Engine {

    class Camera {
    
    	public static Vector2 Position;
        public static float cameraVelocity;
        public static Rectangle Viewport { get; set; }
        public static Rectangle WorldRect { get; set; }
        //public static Matrix Transform = Matrix.Identity;
        public static Rectangle Limits { get; set; }


        public static void Initialize() {

            cameraVelocity = 18f;

            Position = new Vector2(0, 0);
            Viewport = new Rectangle(0, 0, 527, 330);
            Limits = new Rectangle(0, 0, 2037, 330);

        }


        public static void Update() {

            KeyboardState keyboardState = Keyboard.GetState();

            if ( keyboardState.IsKeyDown( Keys.Left ) ) {
                Position += new Vector2( -cameraVelocity, 0 );
            }

            if ( keyboardState.IsKeyDown( Keys.Right ) ) {
                Position += new Vector2( cameraVelocity, 0 );
            }

            Position.X = MathHelper.Clamp(Position.X, Limits.X, Limits.X + Limits.Width - Viewport.Width);

        }

        public static Matrix WorldMovement() {
            
            return Matrix.CreateTranslation( new Vector3(-Position, 0) );

        }


    }

}
