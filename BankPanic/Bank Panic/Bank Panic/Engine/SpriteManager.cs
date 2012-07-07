using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bank_Panic.Engine;
using Bank_Panic.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bank_Panic.Engine
{

    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent {

        //SpriteBatch for drawing
        SpriteBatch spriteBatch;

        //A sprite for the player and a list of automated sprites
        List<Door> listDoor = new List<Door>();
        List<Target> listTarget = new List<Target>();

        public SpriteManager(Game game) : base(game){ }

        public override void Initialize(){
            base.Initialize();
        }

        protected override void LoadContent() {

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            listTarget.Add(new Target(Game.Content.Load<Texture2D>(@"Images/sprTarget"),
                new Vector2(80, 180), new Point(40, 40), 0, new Point(0, 0), new Point(1, 1), Vector2.Zero));
            listTarget[0].setKeyboardKey = Keys.A;

            listTarget.Add(new Target(Game.Content.Load<Texture2D>(@"Images/sprTarget"),
                new Vector2(248, 180), new Point(40, 40), 0, new Point(0, 0), new Point(1, 1), Vector2.Zero));
            listTarget[1].setKeyboardKey = Keys.S;

            listTarget.Add(new Target(Game.Content.Load<Texture2D>(@"Images/sprTarget"), 
                new Vector2(416, 180), new Point(40, 40), 0, new Point(0, 0), new Point(1, 1), Vector2.Zero ));
            listTarget[2].setKeyboardKey = Keys.D;


            listDoor.Add(new Door( Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(46, 114), new Point(109, 161), 0, new Point(0, 0), new Point(4, 2), Vector2.Zero));
            listDoor[0].setId = 1;

            listDoor.Add(new Door( Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(214, 114), new Point(109, 161), 0, new Point(0, 0), new Point(4, 2), Vector2.Zero));
            listDoor[1].setId = 2;

            listDoor.Add(new Door(Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(382, 114), new Point(109, 161), 0, new Point(0, 0),new Point(4, 2), Vector2.Zero));
            listDoor[2].setId = 3;

            listDoor.Add(new Door(Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(550, 114), new Point(109, 161), 0, new Point(0, 0), new Point(4, 2), Vector2.Zero));
            listDoor[3].setId = 4;

            listDoor.Add(new Door(Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(717, 114), new Point(109, 161), 0, new Point(0, 0), new Point(4, 2), Vector2.Zero));
            listDoor[4].setId = 5;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(885, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[5].setId = 6;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(1054, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[6].setId = 7;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(1222, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[7].setId = 8;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(1390, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[8].setId = 9;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(1558, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[9].setId = 10;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(1725, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[10].setId = 11;

            listDoor.Add(new Door(
                Game.Content.Load<Texture2D>(@"Images/doors"),
                new Vector2(1893, 114), new Point(109, 161), 0, new Point(0, 0),
                new Point(4, 2), Vector2.Zero));
            listDoor[11].setId = 12;

            base.LoadContent();
        }


        public override void Update(GameTime gameTime) {
            
            // Update all sprites
            foreach ( Door item in listDoor ){

                item.Update(gameTime, Game.Window.ClientBounds);

                foreach (Target targets in listTarget){
                    
                    targets.Update(gameTime, Game.Window.ClientBounds);

                    //Check for collisions and exit game if there is one
                    if ( targets.isShooting ) {

                        if (item.collisionRect.Intersects(targets.collisionRect))
                        {
                            Console.WriteLine( "Shoot" );
                            Console.WriteLine("Qualé a porta?? " + item.getId);
                        }
                    }
                }
   
            }

            base.Update(gameTime);
        }

        public override void Draw( GameTime gameTime ) {

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone, null, Camera.WorldMovement());

            spriteBatch.Draw(Game.Content.Load<Texture2D>(@"Images/background_full"), new Rectangle(0, 0, 2047, 330), new Rectangle(0, 0, 2047, 330), Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 1.0f);

                foreach ( Sprite item in listDoor )
                    item.Draw( gameTime, spriteBatch );

            spriteBatch.End();


            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            foreach (Target targets in listTarget)
                targets.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw( gameTime );
        }
    }
}
