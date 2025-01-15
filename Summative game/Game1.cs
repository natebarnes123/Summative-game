using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;


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
        Rectangle targetRect1;
        Rectangle targetRect2;
        Texture2D controlScreen;
        Rectangle crosshairRect;
        Rectangle window;
        MouseState mouseState;
        Screen screen;
        Texture2D playBackround;
        bool playing;
        float seconds;
        SpriteFont font;
        int shots;
        Random generator;
        MouseState prevMouseState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            generator = new Random();
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            seconds = 0f;
            targetRect = new Rectangle(350, 350, 150, 150);
            targetRect1 = new Rectangle(200, 450, 150, 150);
            targetRect2 = new Rectangle(100, 200, 150, 150);
            base.Initialize();
            screen = Screen.Intro;
            playing = false;
            shots = 0;
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
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            
            {
                

            }


            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                    screen = Screen.Play;
                if (keyboardState.IsKeyDown(Keys.Right))
                    screen = Screen.Controls;
            }
            else if (screen == Screen.Play)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                    playing = true;

                if (playing)
                {
                    seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (seconds > 20)
                    {
                        seconds = 0f;
                         
                    }

                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (targetRect.Contains(mouseState.Position))
                        {
                            if (mouseState.LeftButton == ButtonState.Pressed &&
                                prevMouseState.LeftButton == ButtonState.Released)
                            {
                                if (targetRect.Contains(mouseState.Position))
                                    shots += 1;
                                targetRect.X = generator.Next(0, 700);
                                targetRect.Y = generator.Next(0, 500);
                            }
                        }

                        if (targetRect1.Contains(mouseState.Position))
                        {
                            if (mouseState.LeftButton == ButtonState.Pressed &&
                                prevMouseState.LeftButton == ButtonState.Released)
                            {
                                if (targetRect1.Contains(mouseState.Position))
                                    shots += 1;
                                targetRect1.X = generator.Next(0, 700);
                                targetRect1.Y = generator.Next(0, 500);
                            }
                        }
                            
                        if (targetRect2.Contains(mouseState.Position))
                        {
                            if (mouseState.LeftButton == ButtonState.Pressed &&
                                prevMouseState.LeftButton == ButtonState.Released)
                            {
                                if (targetRect1.Contains(mouseState.Position))
                                    shots += 1;
                                targetRect2.X = generator.Next(0, 700);
                                targetRect2.Y = generator.Next(0, 500);
                            }
                        }
                            
                    }



                }


            }
            else if(screen == Screen.Controls)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                    screen = Screen.Intro;
            }
            else if (screen == Screen.Win)
            {

            }
            else if (screen == Screen.Lose)
            {

            }



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.Play)
            {
                _spriteBatch.Draw(playBackround, window, Color.White);
                

                if (playing)
                {
                    _spriteBatch.Draw(target, targetRect, Color.White);
                    _spriteBatch.Draw(target, targetRect1, Color.White);
                    _spriteBatch.Draw(target, targetRect2, Color.White);
                    _spriteBatch.DrawString(font, "Targets shot:" + shots, new Vector2(550,10), Color.Black);
                    _spriteBatch.DrawString(font, (20 - seconds).ToString("00"), new Vector2(390, 10), Color.Black);
                    

                }
                else
                {
                    _spriteBatch.DrawString(font, "Press enter to play", new Vector2(275, 260), Color.Black);
                    _spriteBatch.DrawString(font, "Shoot as many targets as you can before the time is up!", new Vector2(10, 40), Color.Black);

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
