using System;
using UnityEngine;

namespace Ikonoclast.Common
{
    [Serializable]
    public struct VerticalDirection : IDirection
    {
        public static readonly VerticalDirection
            UP = new VerticalDirection(true, false),
            DOWN = new VerticalDirection(false, true),
            NONE = new VerticalDirection(false, false);

        #region Properties

        [field: SerializeField]
        public bool Up
        {
            get;
            private set;    // required for serialization
        }

        [field: SerializeField]
        public bool Down
        {
            get;
            private set;    // required for serialization
        }

        public Vector2 AsVector2
        {
            get
            {
                if (Up == Down)
                    return Vector2.zero;

                return Up
                    ? Vector2.up
                    : Vector2.down;
            }
        }

        public Vector3 AsVector3 =>
            AsVector2;

        public VerticalDirection Inverse =>
            new VerticalDirection(!Up, !Down);

        #endregion

        #region Constructors

        public VerticalDirection(bool up, bool down)
        {
            Up = up;
            Down = down;
        }

        #endregion

        #region Methods

        public override int GetHashCode() =>
            base.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is VerticalDirection direction))
                return false;

            return direction == this;
        }

        public static VerticalDirection FromVector2(Vector2 vec2) =>
            vec2.y <= 0
                ? DOWN
                : UP;

        public static VerticalDirection FromVector3(Vector3 vec3) =>
            vec3.y <= 0
                ? DOWN
                : UP;

        public static bool operator ==(VerticalDirection d1, VerticalDirection d2) =>
            d1.Up == d2.Up && d1.Down == d2.Down;

        public static bool operator !=(VerticalDirection d1, VerticalDirection d2) =>
            d1.Up != d2.Up || d1.Down != d2.Down;

        #endregion

        public override string ToString() =>
            AsVector3.ToString();
    }

    [Serializable]
    public struct HorizontalDirection : IDirection
    {
        public static readonly HorizontalDirection
            LEFT = new HorizontalDirection(true, false),
            RIGHT = new HorizontalDirection(false, true),
            NONE = new HorizontalDirection(false, false);

        #region Properties

        [field: SerializeField]
        public bool Left
        {
            get;
            private set;    // required for serialization
        }

        [field: SerializeField]
        public bool Right
        {
            get;
            private set;    // required for serialization
        }

        public Vector2 AsVector2
        {
            get
            {
                if (Left == Right)
                    return Vector2.zero;

                return Left
                    ? Vector2.left
                    : Vector2.right;
            }
        }

        public Vector3 AsVector3 =>
            AsVector2;

        public HorizontalDirection Inverse =>
            new HorizontalDirection(!Left, !Right);

        #endregion

        #region Constructors

        public HorizontalDirection(bool left, bool right)
        {
            Left = left;
            Right = right;
        }

        #endregion

        #region Methods

        public override int GetHashCode() =>
            base.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is HorizontalDirection direction))
                return false;

            return direction == this;
        }

        public static HorizontalDirection FromVector2(Vector2 vec2) =>
            vec2.x < 0
                ? LEFT
                : RIGHT;

        public static HorizontalDirection FromVector3(Vector3 vec3) =>
            vec3.x < 0
                ? LEFT
                : RIGHT;

        public static bool operator ==(HorizontalDirection d1, HorizontalDirection d2) =>
            d1.Left == d2.Left && d1.Right == d2.Right;

        public static bool operator !=(HorizontalDirection d1, HorizontalDirection d2) =>
            d1.Left != d2.Left || d1.Right != d2.Right;

        #endregion

        public override string ToString() =>
            AsVector3.ToString();
    }
}
