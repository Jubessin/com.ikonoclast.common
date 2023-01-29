using UnityEditor;
using UnityEngine;

namespace Ikonoclast.Common.Editor
{
    /// <summary>
    /// Base class for editor window panels.
    /// </summary>
    public abstract class Panel
    {
        #region Fields

        protected Vector2 lastSize;
        protected EditorWindow editor;

        #endregion

        #region Properties

        public virtual Vector2 MinSize =>
            Vector2.zero;

        protected virtual Rect PanelBoxRect
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draw the panel using IMGUI in the OnGUI method.
        /// </summary>
        /// <param name="size"></param>
        public abstract void OnPanelGUI(Vector2 size);

        /// <summary>
        /// Draw the panel using IMGUI in the OnGUI method.
        /// </summary>
        public void OnPanelGUI(float x, float y) => OnPanelGUI(new Vector2(x, y));

        protected abstract void MakeBoxes();
        protected abstract void MakeRects(Vector2 size);

        #endregion
    }
}
