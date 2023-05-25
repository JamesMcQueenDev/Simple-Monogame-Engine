using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP2451Project.SceneManagement
{
    public class SceneGraph : ISceneGraph
    {
        /// <summary>
        /// Draws Entity to Screen
        /// </summary>
        private IDictionary<string, IEntity> _entities;

        public SceneGraph()
        {

        }

        /// <summary>
        /// Passes Through Entity Dictionary To Local Dictionary
        /// </summary>
        /// <param name="pEntities"></param>
        public void AddDictionary(IDictionary<string, IEntity> pEntities)
        {
            _entities = pEntities;
        }

        /// <summary>
        /// Calls Draw on All Entities
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IEntity entity in _entities.Values)
            { 
                entity.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Calls Update on All Entities
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            foreach (IEntity entity in _entities.Values)
            {
                entity.Update(gameTime);
            }
        }
    }
}