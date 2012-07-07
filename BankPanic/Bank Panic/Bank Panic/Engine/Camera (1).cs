using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankPanic.Engine {

    class Camera {
    
    	public static Vector2 Position;
        public static float cameraVelocity;
        public static Rectangle Viewport { get; set; }
        public static Rectangle WorldRect { get; set; }
        //public static Matrix Transform = Matrix.Identity;


        public static void Initialize() {

            cameraVelocity = 4f;

            Position = new Vector2(0, 0);
            Viewport = new Rectangle(0, 0, 800, 480);

        }


        public static void Update() {

            KeyboardState keyboardState = Keyboard.GetState();

            if ( keyboardState.IsKeyDown( Keys.Left ) ) {
                Position += new Vector2( -cameraVelocity, 0 );
            }

            if ( keyboardState.IsKeyDown( Keys.Right ) ) {
                Position += new Vector2( cameraVelocity, 0 );
            }

        }

        public static Matrix WorldMovement() {
            
            return Matrix.CreateTranslation( new Vector3(-Position, 0) );

        }


    }

}
