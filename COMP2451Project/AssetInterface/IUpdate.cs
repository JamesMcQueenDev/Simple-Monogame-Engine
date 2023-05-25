using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project.AssetInterface
{
    public interface IUpdate
    {
        /// <summary>
        /// Holds the Update Method
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);
    }
}