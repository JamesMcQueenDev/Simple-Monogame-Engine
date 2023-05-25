using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2451Project.EntityManagement
{
    /// <summary>
    /// Holds the properties and sets variables of the newly instantiated entity
    /// </summary>
    public abstract class Entity : IEntity
    {
        protected Texture2D _texture;
        protected Vector2 _position, _direction;
        protected string _uname;
        protected int uid;
        protected int _speed = 5;
        protected PlayerIndex playerIndex;

        protected int _screenHeight = 900;
        protected int _screenWidth = 1600;

        /// <summary>
        /// Sets UName of Object
        /// </summary>
        public string UNAME{
            get 
            {
                return _uname;
            }

            set 
            {
                _uname = value;
            }
        }

        /// <summary>
        /// Sets UID of Object
        /// </summary>
        public int UID{
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        /// <summary>
        /// Sets Position of the Player
        /// </summary>
        public Vector2 Position {
            get
            {
                return _position;
            }
            set 
            {
                _position = value;
            } 
        }

        /// <summary>
        /// Sets the Texture of the Object
        /// </summary>
        public Texture2D Texture {
            get
            {
                return _texture;
            }

            set 
            {
                _texture = value;
            } 
        }

        /// <summary>
        /// Sets the PlayerIndex
        /// </summary>
        public PlayerIndex Player {
            get 
            {
                return playerIndex;
            }

            set
            {
                playerIndex = value;
            }
        }

        /// <summary>
        /// Draws Entity
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position);
        }

        /// <summary>
        /// Calls Update On The Child Classes
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);
    }
}