using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BankPanic.Engine
{
    public class Target : Entity{
        
        SpriteBatch m_spriteBatch;
        Texture2D m_sprSquare;
        Rectangle m_sprPosition;

        public Target(Game game, Rectangle position) : base(game)
        {
            m_sprPosition = position;
        }
        
        public override void Initialize(){
            m_spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent(){
            m_sprSquare = Game.Content.Load<Texture2D>("mira");
        }

        public override void Update(GameTime gameTime){

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Console.WriteLine("APERTOU A: IsKeyDown(Keys.A)");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Console.WriteLine("APERTOU S: IsKeyDown(Keys.S)");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Console.WriteLine("APERTOU D: IsKeyDown(Keys.D)");
            }
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int x = m_sprPosition.X + 120;
            int y = m_sprPosition.Y + 160;

            Console.WriteLine("X: " + x);
            Console.WriteLine("Y: " + y);
            
            this.LoadContent();

            spriteBatch.Draw(Game.Content.Load<Texture2D>("mira"), new Rectangle(x, y - 50, 20, 20), Color.White);
        }

        public void GetMoveDir(GameTime gameTime){
            this.Update(gameTime);
        }


    }
}
