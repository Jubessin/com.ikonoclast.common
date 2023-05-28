using UnityEngine;

namespace Ikonoclast.Common
{
    public abstract class Injectable : ScriptableObject, ICreatableAsset
    {
        public abstract void InjectInto(object target);
        public abstract void InjectInto(object target, out object injection);
    }
}