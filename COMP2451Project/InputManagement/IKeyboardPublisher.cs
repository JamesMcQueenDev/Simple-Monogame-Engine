using COMP2451Project.AssetInterface;


namespace COMP2451Project.InputManagement
{
    interface IKeyboardPublisher: IUpdate
    {
        /// <summary>
        /// Holds Subscribe Method
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="listener"></param>
        void Subscribe(string uname, IKeyboardListener listener);

        /// <summary>
        /// Holds Unsubscribe Method
        /// </summary>
        /// <param name="uname"></param>
        void Unsubscribe(string uname);
    }
}
