using UnityEngine;

namespace Ikonoclast.Common
{
    public interface IRaycaster
    {
        bool CastRays
        {
            get;
        }

        Color RaycastColor
        {
            get;
        }
    }
}