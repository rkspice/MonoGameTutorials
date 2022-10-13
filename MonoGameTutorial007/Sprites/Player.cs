using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameTutorial007.Sprites
{
    public class Player : Sprite
    {
        public bool HasDied = false;

        public Player(Texture2D texture) : base(texture)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if (sprite.Rectangle.Intersects(Rectangle))
                    HasDied = true;
            }

            Position += Velocity;

            // Keep the sprite on the screen 
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);

            // Reset the velocity for when the user isn't holding a key. 
            Velocity = Vector2.Zero;
        }

        private void Move()
        {
            if (Input == null)
                throw new Exception("Pleas assign a value to 'input'");

            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;

            if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;
        }
    }
}