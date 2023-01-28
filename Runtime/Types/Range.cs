using System;
using UnityEngine;

namespace Ikonoclast.Common
{
    [Serializable]
    public struct Range<T> : IEquatable<Range<T>>
        where T : IComparable, IFormattable, IComparable<T>, IEquatable<T>
    {
        #region Properties

        [field: SerializeField]
        public T Minimum
        {
            get;
            set;
        }

        [field: SerializeField]
        public T Maximum
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public Range(T minimum, T maximum)
        {
            if (maximum.CompareTo(minimum) > 0)
                throw new ArgumentException($"{nameof(maximum)} cannot be lower than {nameof(minimum)}");

            Minimum = minimum;
            Maximum = maximum;
        }

        #endregion

        #region IEquatable Implementations

        public bool Equals(Range<T> other) =>
            other.Minimum.CompareTo(Minimum) == 0 && other.Maximum.CompareTo(Maximum) == 0;

        #endregion
    }
}
