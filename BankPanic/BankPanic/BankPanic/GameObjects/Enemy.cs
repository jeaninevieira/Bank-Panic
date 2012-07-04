using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BankPanic.GameObjects;
using BankPanic.Engine;

namespace BankPanic.GameObjects
{
    public class Enemy :  Entity {
   

        SpriteBatch spriteBatch;
        Texture2D sprEnemyBad, sprEnemyGood;
        Rectangle sprPosition = new Rectangle(100, 100, 256, 256);

        int iEnemy;
        Random randEnemy = new Random(DateTime.Now.Millisecond);
        

        public Enemy(Game game, Rectangle position) : base(game)
        {
            // TODO: Construct any child components here
            Console.WriteLine("inimigo");
            //iEnemy = 0;
            sprPosition = position;
        }
        
        public override void Initialize(){
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sprEnemyBad = Game.Content.Load<Texture2D>("bad");
            sprEnemyGood = Game.Content.Load<Texture2D>("good");
        }

        public override void Update(GameTime gameTime){

            iEnemy = randEnemy.Next(1,3);

           // base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        //    GraphicsDevice.Clear(Color.CornflowerBlue);

        //    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone);
            int x = sprPosition.X + 92;
            int y = sprPosition.Y + 135;
            if (iEnemy == 1)
            {             
                spriteBatch.Draw(Game.Content.Load<Texture2D>("bad"), new Rectangle(x, y, 80, 120), Color.White);
            }
            else
            {
                spriteBatch.Draw(Game.Content.Load<Texture2D>("good"), new Rectangle(x, y, 80, 120), Color.White);
            }


       //     spriteBatch.End();

        //    base.Draw(gameTime);
        }
    }
}
