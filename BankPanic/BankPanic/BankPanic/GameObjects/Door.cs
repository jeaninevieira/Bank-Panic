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
using BankPanic.Engine;

namespace BankPanic.GameObjects{

    public class Door : Entity {

        SpriteBatch spriteBatch;
        Boolean boolOpenDoor = false, timOn = false;
        Timer openTimer, closeTimer;
        int m_pos;
        Texture2D m_tex1; 
        Texture2D m_tex2;
        Rectangle m_sprPosition;

        Enemy enemy;
        Target target;

        public Door(Game game) : base(game){ }

        public Door(Game game, int pos, Texture2D tex1, Texture2D tex2, Rectangle sprPosition)
            : base(game, pos)
        {
            m_pos  = pos;
            m_tex1 = tex1;
            m_tex2 = tex2;
            m_sprPosition = sprPosition;            
            enemy = new Enemy(game, sprPosition);
            target = new Target(game, sprPosition);
        }

        public override void Initialize(){
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent() { }

        public override void Update(GameTime gameTime){
            
            if (!timOn){
                openTimer = new Timer();
                openTimer.AutoReset = false;
                openTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEventOpen);
                openTimer.Interval = 5000;
                openTimer.Start();
                enemy.Update(gameTime);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (boolOpenDoor)
            {
                spriteBatch.Draw(m_tex2, new Rectangle(m_pos, 100, 256, 256), Color.White);
                this.LoadContent();
                enemy.Draw(gameTime, spriteBatch);
            }
            else
            {
                spriteBatch.Draw(m_tex1, new Rectangle(m_pos, 100, 256, 256), Color.White);
                target.Draw(gameTime, spriteBatch);
            }

            

        }
        
        public void DisplayTimeEventOpen(object source, ElapsedEventArgs e){
            boolOpenDoor = true;
            timOn = true;
            closeTimer = new Timer();
            closeTimer.AutoReset = false;
            closeTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEventClose);
            closeTimer.Interval = 5000;
            closeTimer.Start();
        }

        public void DisplayTimeEventClose(object source, ElapsedEventArgs e){
            boolOpenDoor = false;
            timOn = false;
        }

    }
}
