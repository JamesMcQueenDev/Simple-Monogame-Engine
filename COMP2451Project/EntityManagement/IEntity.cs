using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using COMP2451Project.AssetInterface;



namespace COMP2451Project
{
    public interface IEntity : IUpdate, IDraw
    {   /// <summary>
        /// Holds Properties and Methods of Entiy
        /// </summary>
        string UNAME { get; set; }
        int UID { get; set; }
        
        PlayerIndex Player { get; set; }

        Vector2 Position { get; set; }

        Texture2D Texture { get; set; }
    }
}