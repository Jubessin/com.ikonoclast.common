namespace Ikonoclast.Common
{
    public interface IDispatcher<T> where T : IReceiver
    {
        void Dispatch(Dispatch<T> dispatch);
    }
}
