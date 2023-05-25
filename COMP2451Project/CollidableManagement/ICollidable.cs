
using Microsoft.Xna.Framework;

namespace COMP2451Project.CollidableManagement
{
    public interface ICollidable
    {
        /// <summary>
        /// Holds the Rectangle Property for the PongEntity
        /// </summary>
        Rectangle HitBox { get; }
    }
}