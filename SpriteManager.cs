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


namespace Pilage_and_Plunder
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        UserControlledSprite player;
        List<Sprite> spriteList = new List<Sprite>();

        
        public int points=0;
        public int health=100;


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            player = new UserControlledSprite(
                Game.Content.Load<Texture2D>(@"Images\battleship1"),
                Vector2.Zero, new Point(100, 100), 5, new Point(3,1),
                new Point(4,2), new Vector2(0.5f,0.5f));


            spriteList.Add(new AutomatedSprite(
                Game.Content.Load<Texture2D>(@"Images\buildings"),
                new Vector2(150, 150), new Point(133, 100), 5, new Point(4,0),
                new Point(4,5), Vector2.Zero,"Hit!!!!!",10));

            spriteList.Add(new AutomatedSprite(
                Game.Content.Load<Texture2D>(@"Images\buildings"),
                new Vector2(450, 75), new Point(133, 100), 5, new Point(4, 0),
                new Point(4, 5), Vector2.Zero, "Hit!!!!!!!!",10));

            spriteList.Add(new AutomatedSprite(
                Game.Content.Load<Texture2D>(@"Images\buildings"),
                new Vector2(220, 300), new Point(133, 100), 5, new Point(4, 0),
                new Point(4, 5), Vector2.Zero, "Hit!!!!!",10));

            base.LoadContent();
        }

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (health == 0)
            {
                player.speed = new Vector2(0, 0);
                player.currentFrame.X = 0;
                player.currentFrame.Y = 2;
            }
            else
            {
                //Update Player
                player.Update(gameTime, Game.Window.ClientBounds);


                //Update all sprites
                foreach (Sprite s in spriteList)
                {
                    s.Update(gameTime, Game.Window.ClientBounds);


                    //Check for collisions and exit if there is one
                    if (s.collisionRect.Intersects(player.collisionRect))
                    {


                        points += 5;
                        health -= 2;


                        if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        {
                            player.position.X += 1;


                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        {
                            player.position.X -= 1;

                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        {
                            player.position.Y += 1;

                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        {
                            player.position.Y -= 1;

                        }

                        if ((Keyboard.GetState().IsKeyDown(Keys.Down)) && (Keyboard.GetState().IsKeyDown(Keys.Left)))
                        {
                            player.position.Y -= 1;

                        }

                        if ((Keyboard.GetState().IsKeyDown(Keys.Down)) && (Keyboard.GetState().IsKeyDown(Keys.Right)))
                        {
                            player.position.Y -= 1;

                        }

                        if ((Keyboard.GetState().IsKeyDown(Keys.Up)) && (Keyboard.GetState().IsKeyDown(Keys.Left)))
                        {
                            player.position.Y += 1;

                        }

                        if ((Keyboard.GetState().IsKeyDown(Keys.Up)) && (Keyboard.GetState().IsKeyDown(Keys.Right)))
                        {
                            player.position.Y += 1;

                        }
                    }

                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            //draw the player
            player.Draw(gameTime, spriteBatch);


            //draw all the sprites
            foreach (Sprite s in spriteList)
            {
                s.Draw(gameTime, spriteBatch);
            }
                spriteBatch.End();
                base.Draw(gameTime);
            
        }
    }
}
