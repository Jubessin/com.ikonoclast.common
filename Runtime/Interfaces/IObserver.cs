namespace Ikonoclast.Common
{
    public interface IObserver
    {
        void PropertyChanged(ObserverEventArgs args);
    }
}