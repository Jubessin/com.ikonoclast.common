using System;
using UnityEngine;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    public abstract class RelationalMapper<TKey, TValue> : MonoBehaviour, IRelationalMapper<TKey, TValue>
    {
        #region Fields

        [SerializeField]
        private List<TKey> keys;

        [SerializeField]
        private List<TValue> values;

        [NonSerialized]
        private Dictionary<TKey, TValue> _map = null;

        #endregion

        #region Properties

        public TValue this[TKey key]
        {
            get
            {
                if (Map.TryGetValue(key, out var value))
                    return value;

                Debug.LogWarning($"Could not find value from key {key}.");

                return default;
            }
        }

        [field: SerializeField]
        [field: HideInInspector]
        public bool HasSourceChanged
        {
            get;
            protected set;
        } = true;

        #endregion

        #region IRelationalMapper Implementations

        private Dictionary<TKey, TValue> Map
        {
            get
            {
                if (_map == null)
                {
                    if (keys.Count != values.Count)
                        throw new Exception("List count mismatch");

                    _map = new Dictionary<TKey, TValue>();

                    for (int i = 0; i < keys.Count; i++)
                    {
                        _map.Add(keys[i], values[i]);
                    }
                }

                return _map;
            }
        }

        #endregion

        #region UNITY_EDITOR
#if UNITY_EDITOR

        public List<TKey> Keys
        {
            get => keys;
            set => keys = value;
        }

        public List<TValue> Values
        {
            get => values;
            set => values = value;
        }

        public void SetHasSourceChanged(bool value)
        {
            HasSourceChanged = value;
        }

#endif
        #endregion
    }

    public abstract class IntToString : RelationalMapper<int, string> { }

    public abstract class StringToTransform : RelationalMapper<string, Transform> { }
}