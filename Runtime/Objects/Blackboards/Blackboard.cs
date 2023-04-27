using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ikonoclast.Common
{
    /// <summary>
    /// JSON-serializable <see cref="Map"/>, with distinction for persistent values.
    /// </summary>
    public class Blackboard : Map, IBlackboard
    {
        #region Fields

        [NonSerialized]
        private ReadOnlyBlackboard
            readOnlyCache = null;

        [NonSerialized]
        private readonly HashSet<string>
            persistentIDMap = new HashSet<string>();

        private static Blackboard
            _empty = null;

        #endregion

        #region Properties

        public static Blackboard Empty =>
            _empty ??= new Blackboard(null);

        [JsonIgnore]
        public virtual object this[string key, bool persistent]
        {
            set
            {
                if (this == Empty)
                    throw new NotSupportedException();

                base[key] = value;

                if (persistent)
                {
                    persistentIDMap.Add(key);
                }
            }
        }

        #endregion

        #region Constructors

        public Blackboard(string ID) : base(ID) { }

        #endregion

        #region ISaveObject Implementations

        Map ISaveObject.Serialize()
        {
            if (this == Empty)
                throw new NotSupportedException();

            var map = new Map(ID);

            foreach (var id in persistentIDMap)
            {
                map[id] = base[id];
            }

            return map;
        }

        void ISaveObject.Serialize(Map map, bool overwrite)
        {
            if (this == Empty)
                throw new NotSupportedException();

            if (!overwrite)
            {
                foreach (var id in persistentIDMap)
                {
                    if (!map.HasKey(id))
                    {
                        map[id] = base[id];
                    }
                }
            }
            else
            {
                foreach (var id in persistentIDMap)
                {
                    map[id] = base[id];
                }
            }
        }

        void ISaveObject.Deserialize(Map map)
        {
            if (this == Empty)
                throw new NotSupportedException();

            persistentIDMap.AddRange(map.Keys);

            Copy(map);
        }

        #endregion

        #region IBlackboard Implementations

        public bool IsPersistent(string key) =>
            persistentIDMap.Contains(key);

        public ReadOnlyBlackboard AsReadOnly =>
            readOnlyCache ??= new ReadOnlyBlackboard(this);

        #endregion

        public static implicit operator ReadOnlyBlackboard(Blackboard b) => new ReadOnlyBlackboard(b);
    }
}