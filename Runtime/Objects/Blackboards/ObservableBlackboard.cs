using System.Collections.Generic;

namespace Ikonoclast.Common
{
    public sealed class ObservableBlackboard : Blackboard, IObservable
    {
        #region Fields

        private readonly List<IObserver>
            observers = new List<IObserver>();

        #endregion

        #region Constructors

        public ObservableBlackboard(string ID) : base(ID) { }

        #endregion

        #region Methods

        public void ForceUpdateValue(string key, object value, bool persistent = false)
        {
            base[key, persistent] = value;

            // notify observers
            for (int i = 0; i < observers.Count; ++i)
            {
                observers[i]?.PropertyChanged(key);
            }
        }

        public void SetWithoutNotify(string key, object value, bool persistent = false) =>
            base[key, persistent] = value;

        #endregion

        #region Map Implementations

        public override object this[string key]
        {
            protected get => base[key];
            set
            {
                if (base[key]?.Equals(value) == true)
                    return;

                base[key] = value;

                // notify observers
                for (int i = 0; i < observers.Count; ++i)
                {
                    observers[i]?.PropertyChanged(key);
                }
            }
        }

        public override object this[string key, bool persistent]
        {
            set
            {
                if (base[key]?.Equals(value) == true)
                    return;

                base[key, persistent] = value;

                // notify observers
                for (int i = 0; i < observers.Count; ++i)
                {
                    observers[i]?.PropertyChanged(key);
                }
            }
        }

        #endregion

        #region IObservable Implementations

        public void AddObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        #endregion

        public static implicit operator ReadOnlyBlackboard(ObservableBlackboard b) =>
            new ReadOnlyBlackboard(b);
    }
}