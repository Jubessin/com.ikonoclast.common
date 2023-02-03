using UnityEngine;

namespace Ikonoclast.Common
{
    public class Entity : ScriptableObject, ICreatableAsset
    {
        #region Properties

        public Object Object
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public virtual void Attach(Object Object)
        {
            this.Object = Object;
        }

        #endregion
    }
}
