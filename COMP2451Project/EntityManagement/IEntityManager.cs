using System;
using System.Collections.Generic;


namespace COMP2451Project
{
    public interface IEntityManager
    {
        /// <summary>
        /// Holds the functin which creates and assigns the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uname"></param>
        /// <returns></returns>
        IEntity Create<T>(string uname) where T : IEntity, new();

        /// <summary>
        /// Holds the IDictionary which takes in the instance from kernel
        /// </summary>
        IDictionary<string, IEntity> GetDictionaryInstance {get;}

        /// <summary>
        /// Holds the method which gets rid of the entry held in dictionary
        /// </summary>
        /// <param name="uname"></param>
        void Terminate(string uname);
    }
}
