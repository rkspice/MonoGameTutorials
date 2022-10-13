using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameTutorial004;

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

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        var blueTexture = Content.Load<Texture2D>("blue-box");
        var yellowTexture = Content.Load<Texture2D>("yellow-box");

        _sprites = new List<Sprite>()
        {
            new Sprite(blueTexture)
            {
                Position = new Vector2(100,100),
                Input = new Input()
                {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D
                }
            },
            new Sprite(yellowTexture)
            {
                Position  = new Vector2(100,300),
                Input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right
                }
            }
        };
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        foreach (var sprite in _sprites)
        {
            sprite.Update();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
