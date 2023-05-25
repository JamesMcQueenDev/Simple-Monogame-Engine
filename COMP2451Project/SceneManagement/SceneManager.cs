using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

using COMP2451Project.AssetInterface;
using COMP2451Project.CollidableManagement;

namespace COMP2451Project.SceneManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class SceneManager : ISceneManager, IUpdate, IDraw
    {
        public int screenWidth, screenHeight;

        ISceneGraph sceneGraph;

        public IDictionary<string, IEntity> entities;

        /// <summary>
        /// Constructor for SceneManager
        /// </summary>
        /// <param name="pScreenWidth"></param>
        /// <param name="pScreenHeight"></param>
        /// <param name="pSceneGraph"></param>
        public SceneManager(int pScreenWidth, int pScreenHeight, ISceneGraph pSceneGraph)
        {
            entities = new Dictionary<string, IEntity>();

            sceneGraph = pSceneGraph;

            screenWidth = pScreenWidth;

            screenHeight = pScreenHeight;

            SetObjectDictionary();
        }

        /// <summary>
        /// Passing Entity Dictionary to Collision Manager
        /// </summary>
        /// <param name="collisionManager"></param>
        public void Initialise(ICollisionManager collisionManager)
        {
            collisionManager.Initialise(entities as IReadOnlyDictionary<string, IEntity>);     
        }

        /// <summary>
        /// Adding Entity to Dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public void Spawn(string name, IEntity obj)
        {
            entities.Add(name, obj);
        }

        /// <summary>
        /// Passing Dictionary to SceneGraph
        /// </summary>
        public void SetObjectDictionary()
        {
            sceneGraph.AddDictionary(entities);
        }

        /// <summary>
        /// Property to Set Dictionary Entries passed in from Kernel
        /// </summary>
        public IDictionary<string, IEntity> SetToDictionary
        {
            get
            {
                return entities;
            }
            set
            {
                entities = value;
            }
        }

        /// <summary>
        /// Calling Draw in SceneGraph
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            sceneGraph.Draw(spriteBatch);
        }

        /// <summary>
        /// Calling Update in SceneGraph
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            sceneGraph.Update(gameTime);
        }
    }
}