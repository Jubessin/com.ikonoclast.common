using UnityEngine;

namespace Ikonoclast.Common
{
    public interface IDirection
    {
        Vector2 AsVector2
        {
            get;
        }

        Vector3 AsVector3
        {
            get;
        }
    }
}
