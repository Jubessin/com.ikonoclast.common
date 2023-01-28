using UnityEngine;

namespace Ikonoclast.Common
{
    public sealed class Viewable
    {
        #region Fields

        private bool _isSeen;
        public readonly Transform transform;

        #endregion

        #region Properties

        public bool IsSeen
        {
            get => _isSeen;
            set
            {
                if (_isSeen == value)
                    return;

                _isSeen = value;

                LastTimeSeen = Time.time;
            }
        }

        public double LastTimeSeen
        {
            get;
            private set;
        }

        #endregion

        #region Constructors

        public Viewable(Transform transform)
        {
            this.transform = transform;
        }

        public Viewable(Transform transform, bool isSeen)
        {
            IsSeen = isSeen;
            this.transform = transform;
        }

        #endregion
    }
}