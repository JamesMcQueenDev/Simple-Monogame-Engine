using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using COMP2451Project.AssetInterface;

namespace COMP2451Project.CollidableManagement
{
    /// <summary>
    /// REFERENCE: Marc Price for Collision Management utilising Blackboard Recording
    /// Grabs the list of entities from Scene Manager and iterates throught to see if two objects intersect
    /// </summary>
    ///
    class CollisionManager : ICollisionManager, IUpdate
    {
        //ReadOnlyDictionary used to capture entity dictionary held in the SceneManager
        private IReadOnlyDictionary<string, IEntity> _collidableEntity;

        /// <summary>
        /// Adds Dictionary from Scene Manager
        /// </summary>
        /// <param name="pEntitiy"></param>
        public void Initialise(IReadOnlyDictionary<string, IEntity> pEntitiy)
        {
            _collidableEntity = pEntitiy;
        }

        /// <summary>
        /// Updates The Collision
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //Local List to add values held in dictionary
            IList<ICollidable> collidables = new List<ICollidable>();

            //-------------Adds Objects to Colliadable List---------------//

            //Iterating through all entries with the IEntity interface (which is all of them in this case)
            foreach (IEntity entity in _collidableEntity.Values)
            {
                if (entity is ICollidable)
                {
                    collidables.Add(entity as ICollidable);
                }
            }

            //-------------Iterates through List to Call Collision Detection---------------//

            //Iterating through the local list and comparing two entries that are next to eachother 
            for (int i = 0; i < collidables.Count()-1; i++)
            {
                for (int j = i + 1; j < collidables.Count(); j++)
                {
                    CollisionDetection(collidables[i], collidables[j]);
                }
            }
        }

        /// <summary>
        /// Checks the HitBox Detection of Two Objects
        /// </summary>
        /// <param name="collidable1"></param>
        /// <param name="collidable2"></param>
        private void CollisionDetection(ICollidable collidable1, ICollidable collidable2)
        {
            //Takes in the intersection of the Rectangle called HitBox from PongEntity
            if (collidable1.HitBox.Intersects(collidable2.HitBox))
            {
                //OnCollide is called if ICollidable implements ICollisionResponder

                //This is done for both ICollidables which are called
                if (collidable1 is ICollisionResponder)
                {
                    (collidable1 as ICollisionResponder).OnCollide(collidable2);
                }

                if (collidable2 is ICollisionResponder)
                {
                    (collidable2 as ICollisionResponder).OnCollide(collidable1);
                }
            }
        }
    }
}