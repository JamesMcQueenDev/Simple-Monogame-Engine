using COMP2451Project.AssetInterface;
using System;
using System.Collections.Generic;


namespace COMP2451Project.CollidableManagement
{
    public interface ICollisionManager: IUpdate
    {
        /// <summary>
        /// Holds the Initialise Method
        /// </summary>
        /// <param name="scene"></param>
        void Initialise(IReadOnlyDictionary<String, IEntity> scene);
    }
}