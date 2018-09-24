using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Sprite;

namespace FunWGravity
{
    // Object
    public class Ball : Sprite
    {
        // Attributes
        

        // Behavior
        public Ball(Game game) : base(game)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            this.Location = Vector2.Zero;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// 
        public double vi, t = 0;
        public double g = 520;
        public int keyState = 0;
        ///
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                keyState = 1; vi = -820; // set a velocity of -820 pixels per second
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.Location.X -= 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.Location.X += 2;
            }

            if (keyState == 1)
            {
                // gravitational logic in vertical aspect
                this.Location.Y = (float)(vi * t + g * t * t / 2) + this.Game.GraphicsDevice.Viewport.Height - this.spriteTexture.Height;
                t = t + gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Hack. TO DO, update bounds with obstacles that they cannot pass for bottom
            if (this.Location.Y > GraphicsDevice.Viewport.Height - spriteTexture.Height)
            {
                this.Location.Y = GraphicsDevice.Viewport.Height - spriteTexture.Height;
                keyState = 0;
                t = 0;
            }
            // Hack. TO DO, update bounds with obstacles that they cannot pass
            if (this.Location.X > GraphicsDevice.Viewport.Width - spriteTexture.Width || this.Location.X < 0 - spriteTexture.Width)
            {
                this.Location.X = GraphicsDevice.Viewport.Width - spriteTexture.Width;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void LoadContent()
        {
            this.spriteTexture = this.Game.Content.Load<Texture2D>("ball");

            base.LoadContent();

            this.Location.X = GraphicsDevice.Viewport.Width / 2 - this.spriteTexture.Width / 2; // Place the ball in the middle
            this.Location.Y = GraphicsDevice.Viewport.Height - this.spriteTexture.Height; // Place the ball on the bottom side of the window | the ground
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {

        }
    }
}
