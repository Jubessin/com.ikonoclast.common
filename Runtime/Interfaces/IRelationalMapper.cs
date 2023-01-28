namespace Ikonoclast.Common
{
    public interface IRelationalMapper<in T1, out T2>
    {
        T2 this[T1 key]
        {
            get;
        }
    }
}