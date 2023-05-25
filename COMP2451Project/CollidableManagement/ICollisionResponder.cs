
namespace COMP2451Project.CollidableManagement
{
    public interface ICollisionResponder
    {
        /// <summary>
        /// Holds the OnCollide for the Ball
        /// </summary>
        /// <param name="other"></param>
        void OnCollide(ICollidable other);
    }
}
