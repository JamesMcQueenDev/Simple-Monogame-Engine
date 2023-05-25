using Microsoft.Xna.Framework;

using COMP2451Project.CollidableManagement;


namespace COMP2451Project.EntityManagement
{
    /// <summary>
    /// Holds the HitBox property to set Rectangle of an object, and passes Entity variables to the game objects
    /// </summary>
    public abstract class PongEntity : Entity, ICollidable
    {
        /// <summary>
        /// Creates the Rectangle HitBox for all Objects of PongEntity
        /// </summary>
        public Rectangle HitBox
        {
            get 
            { 
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); 
            }
        }
    }
}