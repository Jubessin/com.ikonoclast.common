using UnityEngine;

namespace Ikonoclast.Common
{
    public interface IScriptableDatabase : ICreatableAsset
    {
        void Clear();

        T Get<T>(string key) where T : ScriptableObject, IIdentity<string>;
    }
}
