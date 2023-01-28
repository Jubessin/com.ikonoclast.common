using System;
using UnityEngine;

namespace Ikonoclast.Common
{
    public abstract class RuntimeContainer<TContainerType> : IContainer<TContainerType>
    {
        #region Properties

        public abstract TContainerType Get
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// ---
        /// This should be used by properties that are only accessible when
        /// not in playmode.
        protected T GetEditorProperty<T>(ref T value)
        {
            if (Application.isPlaying)
                throw new NotSupportedException("get_value");

            return value;
        }

        /// ---
        /// This should be used by properties that are only accessible when 
        /// not in playmode.
        protected void SetEditorProperty<T>(ref T property, T value)
        {
            if (Application.isPlaying)
                throw new NotSupportedException("set_value");

            property = value;
        }

        #endregion
    }
}