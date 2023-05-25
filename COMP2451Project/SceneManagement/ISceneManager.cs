
using System.Collections.Generic;
using COMP2451Project.AssetInterface;
using COMP2451Project.CollidableManagement;

namespace COMP2451Project.SceneManagement
{
    public interface ISceneManager: IDraw, IUpdate
    {
        /// <summary>
        /// Holds method for Spawn
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        void Spawn(string name, IEntity obj);

        /// <summary>
        /// Holds Property for Dictionary
        /// </summary>
        IDictionary<string, IEntity> SetToDictionary { get; set; }

        /// <summary>
        /// Holds the Initialise Method, to pass dictionary to CollisionManager
        /// </summary>
        /// <param name="collisionManager"></param>
        void Initialise(ICollisionManager collisionManager);

        /// <summary>
        /// Holds Method to pass the dictionary to SceneGraph
        /// </summary>
        void SetObjectDictionary();
    }
}