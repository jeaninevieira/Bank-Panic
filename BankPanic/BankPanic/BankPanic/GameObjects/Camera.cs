using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace BankPanic.GameObjects
{
    class Camera
    {
        public static Vector2 Position;
        public static float CameraSpeed;
        public static Rectangle Viewport { get; set; }
        public static Rectangle WorldRect { get; set; }
        public static Matrix Transform = Matrix.Identity;

        public static void Initialize()
        {

            CameraSpeed = 4f;
            Position = new Vector2(0, 0);

            Viewport = new Rectangle(0, 0, 800, 480);

        }


        public static void Update()
        {

            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Left))
                Position += new Vector2(-CameraSpeed, 0);
            if (newState.IsKeyDown(Keys.Right))
                Position += new Vector2(CameraSpeed, 0);

        }

        public static Matrix TransformMatrix()
        {

            Transform = Matrix.CreateTranslation(new Vector3(-Position, 0));
            return Transform;
        }

    }
}
