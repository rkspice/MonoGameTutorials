using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameTutorial006
{
    public class Bullet : Sprite
    {
        private float _timer;

        public Bullet(Texture2D texture)
        : base(texture)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
                IsRemoved = true;

            Position += Direction * LinearVelocity;
        }
    }
}