using System;

namespace Ikonoclast.Common
{
    public sealed class ReadOnlyBlackboard
    {
        #region Fields

        private readonly IBlackboard source;

        #endregion

        #region Constructors

        public ReadOnlyBlackboard(IBlackboard source)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
        }

        #endregion

        #region Methods

        public int GetInt32(string key) =>
            source.GetInt32(key);
        public long GetInt64(string key) =>
            source.GetInt64(key);
        public uint GetUInt32(string key) =>
            source.GetUInt32(key);
        public bool GetBoolean(string key) =>
            source.GetBoolean(key);
        public float GetSingle(string key) =>
            source.GetSingle(key);
        public string GetString(string key) =>
            source.GetString(key);

        public void GetInt32(string key, out int value)
        {
            value = source.GetInt32(key);
        }
        public void GetInt64(string key, out long value)
        {
            value = source.GetInt64(key);
        }
        public void GetUInt32(string key, out uint value)
        {
            value = source.GetUInt32(key);
        }
        public void GetSingle(string key, out float value)
        {
            value = source.GetSingle(key);
        }
        public void GetBoolean(string key, out bool value)
        {
            value = source.GetBoolean(key);
        }
        public void GetString(string key, out string value)
        {
            value = source.GetString(key);
        }

        /// <summary>
        /// Directly access an object from the dictionary.
        /// <br></br>
        /// <br></br>
        /// Note: <b>Cast the returned value at your own risk.</b>
        /// </summary>
        public object GetUnsafe(string key)
            => source.GetUnsafe(key);

        /// <summary>
        /// Directly access an object from the dictionary.
        /// <br></br>
        /// <br></br>
        /// Note: <b>Cast the returned value at your own risk.</b>
        /// </summary>
        public void GetUnsafe(string key, out object value)
        {
            value = source.GetUnsafe(key);
        }

        public bool TryAddObserver(IObserver observer)
        {
            if (source is IObservable observable)
            {
                observable.AddObserver(observer);

                return true;
            }

            return false;
        }

        public bool TryRemoveObserver(IObserver observer)
        {
            if (source is IObservable observable)
            {
                observable.RemoveObserver(observer);

                return true;
            }

            return false;
        }

        #endregion
    }
}