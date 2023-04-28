using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    /// <summary>
    /// This database holds preset references to scriptable objects at runtime. 
    /// </summary>
    public abstract class ScriptableReferenceDatabase<TData> : ScriptableObject, IScriptableDatabase<TData>
        where TData : ScriptableObject, IIdentity<string>
    {
        #region Fields

        [SerializeField]
        protected List<TData> assets;

        protected readonly Dictionary<string, TData>
            assetMap = new Dictionary<string, TData>();

        #endregion

        #region IScriptableDatabase Implementations

        public TData this[string key]
        {
            get
            {
                if (assetMap.TryGetValue(key, out var data))
                    return data;

                data = assets.FirstOrDefault(_data => _data.ID == key);

                if (data == null)
                {
                    Debug.LogWarning($"Could not find asset with key: {key}.");

                    return null;
                }

                return assetMap[key] = data;
            }
        }

        /// <summary>
        /// Unloading will render the database unusable for the session.
        /// </summary>
        public void Clear()
        {
#if !UNITY_EDITOR
            assets.Clear();
            assetMap.Clear();
#else
            Debug.LogWarning("Reference databases cannot be cleared in editor.");
#endif
        }

        #endregion
    }
}
