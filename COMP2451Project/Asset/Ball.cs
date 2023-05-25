using Microsoft.Xna.Framework;
using System;

using COMP2451Project.EntityManagement;
using COMP2451Project.CollidableManagement;


namespace COMP2451Project.Asset
{
    /// <summary>
    /// Holds data for the ball
    /// </summary>
    public class Ball : PongEntity, ICollisionResponder
    {
        //Local Random to set a random direction on serve
        Random rand = new Random();
        //Local invert variable set to an int to invert the ball when it hits the paddle, (i.e go in the opposite direciton) 
        int invert = -1;

        //Constructs Ball and Starts Serve
        public Ball()
        {
            Serve();
        }

        /// <summary>
        /// Method Setting the Directions for Serving
        /// </summary>
        public void Serve()
        {
            //Random Direction set to either -1 or 1
            _direction.X = rand.Next(-1, 2);
            _direction.Y = rand.Next(-1, 2);

            //If either is set to 0, they are assigned 1
            if(_direction.X == 0)
            {
                _direction.X = 1;
            }

            if(_direction.Y == 0)
            {
                _direction.Y = 1;
            }
        }

        /// <summary>
        /// Updating the Position of the Ball
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Check if Ball is within the boundries of the screen
            CheckWallCollision();

            //Updates the Position of the Ball
            _position += _direction * _speed;
        }

        /// <summary>
        /// Checking any initials Wall Collisions
        /// </summary>
        public void CheckWallCollision()
        {
            //If Ball goes beyond either the left or right sides of the screen, the balls position is reset
            if (_position.X <= 0)
            {
                ResetBall();
            }

            if (_position.X >= _screenWidth - (_texture.Width / 2))
            {
                ResetBall();
            }

            if (_position.Y <= 0)
            {
                _direction.Y = 1;
            }

            if (_position.Y >= _screenHeight - (_texture.Height / 2))
            {
                _direction.Y = -1;
            }
        }

        /// <summary>
        /// Resets the Original Position of the Ball when Goal is made and Serves the ball
        /// </summary>
        public void ResetBall()
        {
            //Position reset
            _position.X = _screenWidth / 2 - _texture.Width / 2;
            _position.Y = _screenHeight / 2 - _texture.Height / 2;
            
            //Serve Call
            Serve();
        }

        /// <summary>
        /// Method to change direction
        /// </summary>
        /// <param name="other"></param>
        public void OnCollide(ICollidable other)
        {
            //Inverts the X Direction of the Ball
            _direction.X *= invert;
        }
    }
}