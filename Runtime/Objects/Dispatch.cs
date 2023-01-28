using System;

namespace Ikonoclast.Common
{
    public sealed class Dispatch<T> where T : IReceiver
    {
        #region Fields

        public bool success;

        #endregion

        #region Properties

        public T Receiver
        {
            get;
        }

        #endregion

        #region Constructors

        public Dispatch(T receiver)
        {
            Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            success = false;
        }

        #endregion
    }
}
