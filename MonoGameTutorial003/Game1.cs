using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameTutorial003;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Sprite _blueBoxSprite;
    private Sprite _yellowBoxSprite;

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
        var blueBoxTexture = Content.Load<Texture2D>("blue-box");
        var yellowBoxTexture = Content.Load<Texture2D>("yellow-box");

        _blueBoxSprite = new Sprite(blueBoxTexture)
        {
            Position = new Vector2(300, 200)
        };

        _yellowBoxSprite = new Sprite(yellowBoxTexture)
        {
            Position = new Vector2(400, 200),
            Speed = 4f
        };
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _blueBoxSprite.Update();
        _yellowBoxSprite.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _blueBoxSprite.Draw(_spriteBatch);
        _yellowBoxSprite.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
