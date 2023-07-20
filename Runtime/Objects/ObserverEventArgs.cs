namespace Ikonoclast.Common
{
    public class ObserverEventArgs : System.ComponentModel.PropertyChangedEventArgs
    {
        #region Properties

        public object OldValue
        {
            get;
        }

        public object NewValue
        {
            get;
        }

        #endregion

        #region Constructors

        public ObserverEventArgs(string propertyName, object oldValue, object newValue) : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        #endregion
    }
}
