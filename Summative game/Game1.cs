using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Summative_game
{
    enum Screen
    {
        Intro,
        Controls,
        Play,
        Lose,
        Win
    }



    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D Intro;
        Texture2D target;
        Texture2D crosshair;
        Rectangle targetRect;
        Rectangle crosshairRect;
        Rectangle window;
        MouseState mouseState;
        Screen screen;
        SpriteFont font;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            crosshairRect = new Rectangle(330, 210, 150, 150);
            targetRect = new Rectangle(350, 350, 150, 150);
            base.Initialize();
            screen = Screen.Intro;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            target = Content.Load<Texture2D>("target");
            crosshair = Content.Load<Texture2D>("crosshair");
            Intro = Content.Load<Texture2D>("Intro");
            font = Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.Play)
            {
                _spriteBatch.Draw(target, targetRect, Color.White);
                _spriteBatch.Draw(crosshair, crosshairRect, Color.White);
            }
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(Intro, window, Color.White);
                _spriteBatch.DrawString(font, "Left click to play", new Vector2(550, 300), Color.White);
            }
            
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
