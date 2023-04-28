using UnityEngine;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    /// <summary>
    /// This database loads references to scriptable objects at runtime. 
    /// </summary>
    public abstract class ScriptableResourceDatabase<TData> : IScriptableDatabase<TData>
        where TData : ScriptableObject, IIdentity<string>
    {
        #region Fields

        protected readonly Dictionary<string, TData>
            assetMap = new Dictionary<string, TData>();

        #endregion

        #region Properties

        public bool IsLoaded
        {
            get;
            protected set;
        }

        #endregion

        #region IScriptableDatabase Implementations

        public TData this[string key]
        {
            get
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
                    return data;

                Debug.LogWarning($"Asset with key: {key} does not exist in the Resources folder.");

                return null;
            }
        }

        public void Clear()
        {
            assetMap.Clear();

            IsLoaded = false;
        }

        #endregion
    }
}
