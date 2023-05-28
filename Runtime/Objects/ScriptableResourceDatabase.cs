using UnityEngine;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    /// <summary>
    /// This database loads references to scriptable objects at runtime. 
    /// </summary>
    public abstract class ScriptableResourceDatabase : IScriptableDatabase
    {
        #region IScriptableDatabase Implementations

        public abstract void Clear();

        public abstract T Get<T>(string key) where T : ScriptableObject, IIdentity<string>;

        #endregion
    }

    /// <summary>
    /// This database loads references to scriptable objects at runtime. 
    /// </summary>
    public abstract class ScriptableResourceDatabase<TData> : ScriptableResourceDatabase
        where TData : ScriptableObject, IIdentity<string>
    {
        #region Fields

        private readonly Dictionary<string, TData>
            assetMap = new Dictionary<string, TData>();

        #endregion

        #region Properties

        public bool IsLoaded
        {
            get;
            private set;
        }

        public TData this[string key] => Get<TData>(key);

        #endregion

        #region IScriptableDatabase Implementations

        public override void Clear()
        {
            assetMap.Clear();

            IsLoaded = false;
        }

        public override T Get<T>(string key)
        {
            if (!IsLoaded)
            {
                var assets = Resources.LoadAll<TData>(string.Empty);

                foreach (var asset in assets)
                {
                    assetMap[asset.ID] = asset;
                }

                IsLoaded = true;
            }

            if (assetMap.TryGetValue(key, out var data))
                return data as T;

            Debug.LogWarning($"Asset with key: {key} does not exist in the Resources folder.");

            return null;
        }

        #endregion
    }
}
