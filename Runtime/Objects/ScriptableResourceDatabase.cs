using UnityEngine;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    public abstract class ScriptableResourceDatabase<TData> : IScriptableDatabase<TData>
        where TData : ScriptableObject, IIdentity<string>
    {
        #region Fields

        private bool isLoaded;

        private readonly Dictionary<string, TData>
            assetMap = new Dictionary<string, TData>();

        #endregion

        #region IScriptableDatabase Implementations

        public TData this[string key]
        {
            get
            {
                if (!isLoaded)
                {
                    var assets = Resources.LoadAll<TData>(string.Empty);

                    foreach (var asset in assets)
                    {
                        assetMap[asset.ID] = asset;
                    }

                    isLoaded = true;
                }

                if (assetMap.TryGetValue(key, out var data))
                    return data;

                Debug.LogWarning($"Asset with key: {key} does not exist in Resources.");

                return null;
            }
        }

        public void Clear()
        {
            assetMap.Clear();

            isLoaded = false;
        }

        #endregion
    }
}
