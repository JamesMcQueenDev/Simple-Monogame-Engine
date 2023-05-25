using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using COMP2451Project.EntityManagement;
using COMP2451Project.InputManagement;

namespace COMP2451Project.Asset
{
    /// <summary>
    /// Holds data for the paddle
    /// </summary>
    public class Paddle : PongEntity, IKeyboardListener
    {
        /// <summary>
        /// Constructs Paddle
        /// </summary>
        public Paddle()
        {
           
        }

        /// <summary>
        /// Updates Position of Paddle
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Calls to Check if Paddle is within boundry
            CheckWallCollision();

            //Gets Input Direction for the Paddle
            //_direction = Input.GetKeyboardInputDirection(playerIndex);
            
            //Position being Updated
            _position += _direction * _speed;
        }

        /// <summary>
        /// Checks for Wall Collision
        /// </summary>
        public void CheckWallCollision()
        {
            if (_position.Y <= 0)
            {
                //Top of the Paddle goes no further than the top edge of the screen
                _position.Y = 0;
            }
            if (_position.Y >= _screenHeight - _texture.Height)
            {
                //Bottom of the Paddle goes no further thatn the bottom edge of the screen
                _position.Y = _screenHeight - _texture.Height;
            }
        }

        /// <summary>
        /// On Input Method
        /// </summary>
        /// <param name="keyboardState"></param>
        public void OnInput(KeyboardState keyboardState)
        {
            _direction = new Vector2(0, 0);

            if (playerIndex == PlayerIndex.One)
            {
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    _direction.Y = -1;
                }

                if (keyboardState.IsKeyDown(Keys.S))
                {
                    _direction.Y = 1;
                }
            }

            if (playerIndex == PlayerIndex.Two)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    _direction.Y = -1;
                }

                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    _direction.Y = 1;
                }
            }
        }
        
    }
}