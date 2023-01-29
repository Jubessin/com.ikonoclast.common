using UnityEngine;

namespace Ikonoclast.Common.Editor
{
    public interface ICustomEditorWindow
    {
        bool IsMouseInFocusable
        {
            get;
        }

        void HandleWindowReposition();
        void AddFocusable(Rect rect);
        void RemoveFocusable(Rect rect);
    }
}
