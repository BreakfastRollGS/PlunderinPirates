using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pilage_and_Plunder
{
    class UserControlledSprite : Sprite
    {

        public UserControlledSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
    sheetSize, speed,null, 0)
        {
        }//end method

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
            int millisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, null,0)
        {
        }//end method

        public override Vector2 direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    inputDirection.X -= 1;
                    currentFrame.X = 2;
                    currentFrame.Y = 0;
                    
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    inputDirection.X += 1;
                    currentFrame.X = 1;
                    currentFrame.Y = 0;
                    speed = new Vector2(0.5f, 0.5f);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    inputDirection.Y -= 1;
                    currentFrame.X = 0;
                    currentFrame.Y = 0;
                    speed = new Vector2(0.5f, 0.5f);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    inputDirection.Y += 1;
                    currentFrame.X = 0;
                    currentFrame.Y = 1;
                    speed = new Vector2(0.5f, 0.5f);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Down)) && (Keyboard.GetState().IsKeyDown(Keys.Left)))
                {
                    inputDirection.Y += 1;
                    currentFrame.X = 2;
                    currentFrame.Y = 1;
                    speed = new Vector2(0.5f, 0.5f);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Down)) && (Keyboard.GetState().IsKeyDown(Keys.Right)))
                {
                    inputDirection.Y += 1;
                    currentFrame.X = 1;
                    currentFrame.Y = 1;
                    speed = new Vector2(0.5f, 0.5f);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Up)) && (Keyboard.GetState().IsKeyDown(Keys.Left)))
                {
                    inputDirection.Y += -1;
                    currentFrame.X = 3;
                    currentFrame.Y = 1;
                    speed = new Vector2(0.5f, 0.5f);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Up)) && (Keyboard.GetState().IsKeyDown(Keys.Right)))
                {
                    inputDirection.Y += -1;
                    currentFrame.X = 3;
                    currentFrame.Y = 0;
                    speed = new Vector2(0.5f, 0.5f);
                }

                return inputDirection * speed;
            }//end get
        }//end method

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            //move the sprite based on direction
            position += direction;

            //If sprite is off the screen, move it back within the game window
            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > clientBounds.Width - frameSize.X)
                position.X = clientBounds.Width - frameSize.X;
            if (position.Y > clientBounds.Height - frameSize.Y)
                position.Y = clientBounds.Height - frameSize.Y;

            base.Update(gameTime, clientBounds);
        }

    }//end class
}// end namespace
