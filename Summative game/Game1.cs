using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


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
        KeyboardState keyboardState;
        Texture2D Intro;
        Texture2D target;
        Texture2D crosshair;
        Rectangle targetRect;
        Texture2D controlScreen;
        Rectangle crosshairRect;
        Rectangle window;
        MouseState mouseState;
        Screen screen;
        Texture2D playBackround;
        
        SpriteFont font;
        int point;
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
            controlScreen = Content.Load<Texture2D>("Controls");
            playBackround = Content.Load<Texture2D>("playBackround");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
                screen = Screen.Play;
            if (keyboardState.IsKeyDown(Keys.Right))
               screen = Screen.Controls;
            if (keyboardState.IsKeyDown(Keys.Up))
                screen = Screen.Intro;
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
                _spriteBatch.Draw(playBackround,window, Color.White);
                _spriteBatch.Draw(target, targetRect, Color.White);
                _spriteBatch.DrawString(font, "Press enter to play", new Vector2(150, 100), Color.Black);
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                 _spriteBatch.Draw(target, targetRect, Color.White);
                }

            }
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(Intro, window, Color.White);
                _spriteBatch.DrawString(font, "Left arrow to play", new Vector2(200, 350), Color.White);
                _spriteBatch.DrawString(font, "Right arrow for controls", new Vector2(200, 100), Color.White);
            }
            if (screen == Screen.Controls)
            {
                _spriteBatch.Draw(controlScreen, window, Color.White);
                _spriteBatch.DrawString(font, "Use your mouse to aim.", new Vector2(125, 150), Color.White);
                _spriteBatch.DrawString(font, "Press upkey to return to menu.", new Vector2(125, 225), Color.White);

            }
                
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
