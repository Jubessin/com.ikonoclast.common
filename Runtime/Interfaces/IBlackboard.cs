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

        public T Get<T>(string key);
        public object Get(string key);
        public int GetInt32(string key);
        public long GetInt64(string key);
        public uint GetUInt32(string key);
        public bool GetBoolean(string key);
        public float GetSingle(string key);
        public string GetString(string key);

        public void Get<T>(string key, out T value);
        public void Get(string key, out object value);
        public void GetInt32(string key, out int value);
        public void GetInt64(string key, out long value);
        public void GetUInt32(string key, out uint value);
        public void GetSingle(string key, out float value);
        public void GetBoolean(string key, out bool value);
        public void GetString(string key, out string value);
    }
}
