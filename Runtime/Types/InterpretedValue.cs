using System;
using UnityEngine;

namespace Ikonoclast.Common
{
    [Serializable]
    public class InterpretedValue
    {
        #region Fields

        [SerializeField]
        protected string rawValue;

        [SerializeField]
        protected char
            rawValueTypePrefix = 's';

        [NonSerialized]
        protected bool
            isDirty = true;

        [NonSerialized]
        protected object
            actualValue = null;

        #endregion

        #region Properties

        public object Get
        {
            get
            {
                if (isDirty)
                {
                    Interpret();

                    isDirty = false;
                }

                return actualValue;
            }
        }

        public string RawValue
        {
            get => GetEditorProperty(ref rawValue);
            set
            {
                if (Application.isPlaying)
                    throw new NotSupportedException("set_" + nameof(RawValue));

                if (value != rawValue)
                {
                    isDirty = true;
                }

                rawValue = value;
            }
        }

        public virtual char RawValueTypePrefix
        {
            get => GetEditorProperty(ref rawValueTypePrefix);
            set
            {
                if (Application.isPlaying)
                    throw new NotSupportedException("set_" + nameof(RawValueTypePrefix));

                if (rawValueTypePrefix == value)
                    return;

                rawValueTypePrefix = value;

                switch (value)
                {
                    case Values.FloatPrefix:
                        rawValue = Values.FloatDefault;
                        break;

                    case Values.IntegerPrefix:
                        rawValue = Values.IntegerDefault;
                        break;

                    case Values.BooleanPrefix:
                        rawValue = Values.BooleanDefault;
                        break;

                    case Values.Vector2Prefix:
                        rawValue = Values.Vector2Default;
                        break;

                    default:
                        rawValue = Values.StringDefault;
                        break;
                }

                isDirty = true;
            }
        }

        #endregion

        #region Methods

        protected virtual void Interpret()
        {
            switch (rawValueTypePrefix)
            {
                case Values.IntegerPrefix:
                    actualValue = int.Parse(rawValue);
                    break;

                case Values.BooleanPrefix:
                    actualValue = bool.Parse(rawValue);
                    break;

                case Values.FloatPrefix:
                    actualValue = float.Parse(rawValue);
                    break;

                case Values.Vector2Prefix:
                    actualValue = VectorParse(rawValue);
                    break;

                default:
                    actualValue = rawValue;
                    break;
            }

            static Vector2 VectorParse(string value)
            {
                var stringedVector = value.Substring(1, value.Length - 1 - 1);

                var stringedVectorValues = stringedVector.Split(',');

                System.Globalization.NumberStyles parseStyle =
                    System.Globalization.NumberStyles.Float |
                    System.Globalization.NumberStyles.AllowThousands;

                return new Vector2
                (
                    float.Parse(stringedVectorValues[0], parseStyle),
                    float.Parse(stringedVectorValues[1], parseStyle)
                );
            }
        }

        /// ---
        /// This should be used by properties that are only accessible when
        /// not in playmode.
        protected T GetEditorProperty<T>(ref T value)
        {
            if (Application.isPlaying)
                throw new NotSupportedException("get_value");

            return value;
        }

        #endregion
    }
}