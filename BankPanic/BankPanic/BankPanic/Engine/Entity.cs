using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BankPanic.Engine{

    public abstract class Entity : Microsoft.Xna.Framework.DrawableGameComponent{

        int nextState = 0;
        bool changeState = false;
        int m_pos;
    
        public bool ChangeState{
            get { return changeState; }
            set { changeState = value; }
        }

        public int NextState{
            get { return nextState; }
            set { nextState = value; }
        }

        public Entity(Game game) : base(game){ }

        public Entity(Game game, int pos)
            : base(game)
        {
            m_pos = pos;
        }


        public bool IsStateChange(){
            if (changeState){
                changeState = false;
                return true;
            }
            return false;
        }

        public override void Initialize(){
            base.Initialize();
        }

        public override void Update(GameTime gameTime){
            base.Update(gameTime);
        }

        protected override void LoadContent() { }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
      
    }
}
