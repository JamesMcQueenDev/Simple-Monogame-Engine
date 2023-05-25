
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace COMP2451Project.InputManagement
{
    class InputManager : IKeyboardPublisher
    {
        /// <summary>
        /// REFERENCE: Marc Price for Input Management utilising Blackboard Recording
        /// </summary>
        
        Dictionary<string, IKeyboardListener>  keyBoardListener;
        
        public InputManager()
        {
            keyBoardListener = new Dictionary<string, IKeyboardListener>();
        }

        /// <summary>
        /// Subscribes the listener to dictionary by adding
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="listener"></param>
        public void Subscribe(string uname, IKeyboardListener listener)
        {
            keyBoardListener.Add(uname, listener);
        }

        /// <summary>
        /// Unsubscribes the listener by removing it from dictionary
        /// </summary>
        /// <param name="uname"></param>
        public void Unsubscribe(string uname)
        {
            keyBoardListener.Remove(uname);
        }

        /// <summary>
        /// Updates and Iterates through keyBoardListener Dictionary
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            foreach(IKeyboardListener entity in keyBoardListener.Values)
            {
                entity.OnInput(keyState);
            }
        }
    }
}
