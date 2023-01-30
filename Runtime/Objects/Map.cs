using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    /// <summary>
    /// Identifiable, typeless dictionary with overrideable getter, setter.
    /// </summary>
    [Serializable]
    public class Map : IIdentity<string>
    {
        #region Fields

        [JsonRequired]
        [JsonProperty(Required = Required.DisallowNull, PropertyName = "ID")]
        private string _id;

        [JsonRequired]
        [JsonProperty(Required = Required.DisallowNull, PropertyName = "data")]
        private Dictionary<string, object> _data;

        #endregion

        #region Properties

        [JsonIgnore]
        public string ID => _id;

        [JsonIgnore]
        public virtual object this[string key]
        {
            protected get
            {
                if (string.IsNullOrWhiteSpace(key))
                    return null;

                if (_data == null)
                    return null;

                if (_data.TryGetValue(key, out var obj))
                    return obj;

                return null;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                    return;

                if (_data == null)
                    return;

                _data[key] = value;
            }
        }

        #endregion

        #region Constructors

        public Map(string ID)
        {
            _id = ID;

            _data = new Dictionary<string, object>();
        }

        #endregion

        #region Methods

        public bool HasKey(string key) =>
            _data.ContainsKey(key);

        public int GetInt32(string key) =>
            Convert.ToInt32(this[key]);
        public long GetInt64(string key) =>
            Convert.ToInt64(this[key]);
        public uint GetUInt32(string key) =>
            Convert.ToUInt32(this[key]);
        public bool GetBoolean(string key) =>
            Convert.ToBoolean(this[key]);
        public float GetSingle(string key) =>
            Convert.ToSingle(this[key]);
        public string GetString(string key) =>
            (string)this[key];

        public void GetInt32(string key, out int value)
        {
            value = Convert.ToInt32(this[key]);
        }
        public void GetInt64(string key, out long value)
        {
            value = Convert.ToInt64(this[key]);
        }
        public void GetUInt32(string key, out uint value)
        {
            value = Convert.ToUInt32(this[key]);
        }
        public void GetSingle(string key, out float value)
        {
            value = Convert.ToSingle(this[key]);
        }
        public void GetBoolean(string key, out bool value)
        {
            value = Convert.ToBoolean(this[key]);
        }
        public void GetString(string key, out string value)
        {
            value = (string)this[key];
        }

        /// <summary>
        /// Explicitly cast dictionary value to <see cref="bool"/>.
        /// </summary>
        public bool GetRawBoolean(string key) =>
            (bool)this[key];

        /// <summary>
        /// Explicitly cast dictionary value to <see cref="bool"/>.
        /// </summary>
        public void GetRawBoolean(string key, out bool value)
        {
            value = (bool)this[key];
        }

        /// <summary>
        /// Directly access an object from the dictionary.
        /// <br></br>
        /// <br></br>
        /// Note: <b>Cast the returned value at your own risk.</b>
        /// </summary>
        public object GetUnsafe(string key)
            => this[key];

        /// <summary>
        /// Directly access an object from the dictionary.
        /// <br></br>
        /// <br></br>
        /// Note: <b>Cast the returned value at your own risk.</b>
        /// </summary>
        public void GetUnsafe(string key, out object value)
        {
            value = this[key];
        }

        protected void Copy(Map map)
        {
            if (map == null || map._data == null)
                return;

            _data = new Dictionary<string, object>(map._data);
        }

        #endregion
    }
}
