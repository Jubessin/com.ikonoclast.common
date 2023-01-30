namespace Ikonoclast.Common
{
    public interface IBlackboard : ISaveObject
    {
        object this[string key]
        {
            set;
        }
        ReadOnlyBlackboard AsReadOnly
        {
            get;
        }

        public int GetInt32(string key);
        public long GetInt64(string key);
        public uint GetUInt32(string key);
        public bool GetBoolean(string key);
        public float GetSingle(string key);
        public string GetString(string key);

        public void GetInt32(string key, out int value);
        public void GetInt64(string key, out long value);
        public void GetUInt32(string key, out uint value);
        public void GetSingle(string key, out float value);
        public void GetBoolean(string key, out bool value);
        public void GetString(string key, out string value);

        /// <summary>
        /// Directly access an object from the dictionary.
        /// <br></br>
        /// <br></br>
        /// Note: <b>Cast the returned value at your own risk.</b>
        /// </summary>
        public object GetUnsafe(string key);

        /// <summary>
        /// Directly access an object from the dictionary.
        /// <br></br>
        /// <br></br>
        /// Note: <b>Cast the returned value at your own risk.</b>
        /// </summary>
        public void GetUnsafe(string key, out object value);
    }
}
