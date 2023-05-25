
using System.Collections.Generic;
using COMP2451Project.AssetInterface;


namespace COMP2451Project.SceneManagement
{
    public interface ISceneGraph : IDraw, IUpdate
    {
        /// <summary>
        /// Holds AddDictionary Method
        /// </summary>
        /// <param name="pEntities"></param>
        void AddDictionary(IDictionary<string, IEntity> pEntities);
    }
}
