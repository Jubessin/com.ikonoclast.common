using UnityEngine;

namespace Ikonoclast.Common
{
    public interface IScriptableDatabase<TData> : ICreatableAsset
        where TData : ScriptableObject, IIdentity<string>
    {
        TData this[string key]
        {
            get;
        }

        void Clear();
    }
}
