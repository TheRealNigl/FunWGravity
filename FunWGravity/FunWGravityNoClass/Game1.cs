using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FunWGravityNoClass
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ball;
        Vector2 ballLocation;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 920;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ball = Content.Load<Texture2D>("ball");

            base.LoadContent();

            ballLocation.X = GraphicsDevice.Viewport.Width / 2 - ball.Width / 2; // Place the ball in the middle
            ballLocation.Y = GraphicsDevice.Viewport.Height - ball.Height; // Place the ball on the bottom side of the window | the ground
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public double vi, t = 0;
        public double g = 520;
        public int keyState = 0;
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                keyState = 1; vi = -820; // set a velocity of -820 pixels per second
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                ballLocation.X -= 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                ballLocation.X += 2;
            }

            if (keyState == 1)
            {
                // gravitational logic in vertical aspect
                ballLocation.Y = (float)(vi * t + g * t * t / 2) + graphics.GraphicsDevice.Viewport.Height - ball.Height;
                t = t + gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Hack. TO DO, update bounds with obstacles that they cannot pass for bottom
            if (ballLocation.Y > GraphicsDevice.Viewport.Height - ball.Height)
            {
                ballLocation.Y = GraphicsDevice.Viewport.Height - ball.Height;
                keyState = 0;
                t = 0;
            }
            // Hack. TO DO, update bounds with obstacles that they cannot pass
            if (ballLocation.X > GraphicsDevice.Viewport.Width - ball.Width || ballLocation.X < 0 - ball.Width)
            {
                ballLocation.X = GraphicsDevice.Viewport.Width - ball.Width;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(ball, ballLocation, Color.AntiqueWhite);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
