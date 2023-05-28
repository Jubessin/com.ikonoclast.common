using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    /// <summary>
    /// This database holds preset references to scriptable objects at runtime. 
    /// </summary>
    public abstract class ScriptableReferenceDatabase : ScriptableObject, IScriptableDatabase
    {
        #region IScriptableDatabase Implementations

        /// <summary>
        /// Unloading will render the database unusable for the session.
        /// </summary>
        public virtual void Clear()
        {
#if UNITY_EDITOR
            Debug.LogWarning("Reference databases cannot be cleared in editor.");
#endif
        }

        public abstract T Get<T>(string key) where T : ScriptableObject, IIdentity<string>;

        #endregion
    }

    /// <summary>
    /// This database holds preset references to scriptable objects at runtime. 
    /// </summary>
    public abstract class ScriptableReferenceDatabase<TData> : ScriptableReferenceDatabase
        where TData : ScriptableObject, IIdentity<string>
    {
        #region Fields

        [SerializeField]
        private List<TData> assets;

        private readonly Dictionary<string, TData>
            assetMap = new Dictionary<string, TData>();

        #endregion

        #region Properties

        public TData this[string key] => Get<TData>(key);

        #endregion

        #region IScriptableDatabase Implementations

        /// <summary>
        /// Unloading will render the database unusable for the session.
        /// </summary>
        public override void Clear()
        {
#if !UNITY_EDITOR
            assets.Clear();
            assetMap.Clear();
#else
            Debug.LogWarning("Reference databases cannot be cleared in editor.");
#endif
        }

        public override T Get<T>(string key)
        {
            if (assetMap.TryGetValue(key, out var data))
                return data as T;

            data = assets.FirstOrDefault(_data => _data.ID == key);

            if (data == null)
            {
                Debug.LogWarning($"Could not find asset with key: {key}.");

                return null;
            }

            return (assetMap[key] = data) as T;
        }

        #endregion
    }
}
