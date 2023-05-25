
using System.Collections.Generic;


namespace COMP2451Project
{
     /// <summary>
     /// Creates entity from Kernel and adds it to a dictionary
     /// </summary>
    class EntityManager : IEntityManager
    {
        //Local Dictionary to hold the each entry passed in from Kernel
        Dictionary<string, IEntity> dictionaryEntity;

        //Local int to hold the id number of the entity
        int idAssign = 0;

        //Constructs EntityManager and instantiates the Dictionary
        public EntityManager()
        {
            dictionaryEntity = new Dictionary<string, IEntity>(); 
        }

        /// <summary>
        /// Property that returns the instance from kernel and holds in local dictionary
        /// </summary>
        public IDictionary<string, IEntity> GetDictionaryInstance
        {
            get 
            {
                return dictionaryEntity;   
            }
        }

        /// <summary>
        /// Functions which creates Entity, by adding its name and type to the dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uname"></param>
        /// <returns></returns>
        public IEntity Create<T>(string uname) where T: IEntity, new()
        {
            T type = new T();
            dictionaryEntity.Add(uname, type);

            //Assigning ID and Name to the object properties
            type.UID = idAssign;
            type.UNAME = uname;
            idAssign++;

            return dictionaryEntity[uname];
        }

        /// <summary>
        /// Removes entity from the dictionary with the corresponding entity name
        /// </summary>
        /// <param name="uname"></param>
        public void Terminate(string uname)
        {
            dictionaryEntity.Remove(uname);
        }
    }
}
