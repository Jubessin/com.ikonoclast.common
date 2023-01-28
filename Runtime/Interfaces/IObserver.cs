namespace Ikonoclast.Common
{
    public interface IObserver
    {
        void PropertyChanged(string propertyName);
        void PropertyChanged(string propertyName, object oldValue, object newValue);
    }
}