
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project.InputManagement
{
    interface IKeyboardListener
    {
        /// <summary>
        /// Holds the OnInput
        /// </summary>
        /// <param name="keyboardState"></param>
        void OnInput(KeyboardState keyboardState);
    }
}