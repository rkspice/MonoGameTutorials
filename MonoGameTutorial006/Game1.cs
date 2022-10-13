using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameTutorial006;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<Sprite> _sprites;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _sprites = new List<Sprite>
        {
            new Ship(Content.Load<Texture2D>("Ship"))
            {
                Position = new Vector2(100,100),
                Bullet = new Bullet(Content.Load<Texture2D>("Bullet"))
            },
        };


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        foreach (var sprite in _sprites.ToArray())
            sprite.Update(gameTime, _sprites);

        PostUpdate();

        base.Update(gameTime);
    }

    private void PostUpdate()
    {
        for (int i = 0; i < _sprites.Count; i++)
            if (_sprites[i].IsRemoved)
            {
                _sprites.RemoveAt(i);
                i--;
            }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        foreach (var sprite in _sprites)
            sprite.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
