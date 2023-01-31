using UnityEditor;
using UnityEngine;

namespace Ikonoclast.Common.Editor
{
    using Ikonoclast.Common;

    using static PanelUtils;
    using static CustomEditorHelper;

    /// <summary>
    /// Base class for settings panels.
    /// </summary>
    public abstract class SettingsPanel : Panel, IEditorSaveObject
    {
        #region Events

        public delegate void Request();

        #endregion

        #region Fields

        protected Rect
            scrollViewRect,
            settingsMainRect,
            historyButtonRect,
            settingsItemBoxRect,
            settingsItemNameRect,
            settingsItemFieldRect,
            clearHistoryButtonRect,
            settingsItemToggleRect,
            clearFavoritesButtonRect;

        protected Vector2
            scrollViewPos;

        protected readonly GUIStyle
            customFieldStyle;

        protected readonly GUIContent
            labelContentCache;

        #endregion

        #region Properties

        protected abstract string Title { get; }

        protected Rect TitleBoxRect { get; set; }

        protected Rect HeaderBoxRect { get; set; }

        protected abstract int SettingsCount { get; }

        #endregion

        #region Constructors

        protected SettingsPanel()
        {
            labelContentCache = new GUIContent();
            customFieldStyle = new GUIStyle(TextFieldStyle);
        }

        #endregion

        #region Methods

        private void UpdateRects()
        {
            settingsItemBoxRect.y += slh * 2 + 5;

            settingsItemNameRect.y = settingsItemBoxRect.y + 1;

            settingsItemFieldRect.y = settingsItemBoxRect.y + 5;

            settingsItemToggleRect.y = settingsItemBoxRect.y + 10;
        }

        protected int MakeSetting(string label, int value)
        {
            MakeBox(settingsItemBoxRect);

            labelContentCache.text = label;
            labelContentCache.tooltip = label;
            GUI.Label(settingsItemNameRect, labelContentCache, EditorStyles.boldLabel);

            customFieldStyle.padding.left = 0;
            customFieldStyle.padding.right = 5;
            customFieldStyle.alignment = TextAnchor.MiddleRight;
            value = EditorGUI.IntField(settingsItemFieldRect, value, customFieldStyle);

            UpdateRects();

            return value;
        }
        protected int MakeSetting(string label, int value, int min, int max)
        {
            MakeBox(settingsItemBoxRect);

            labelContentCache.text = label;
            labelContentCache.tooltip = label;
            GUI.Label(settingsItemNameRect, labelContentCache, EditorStyles.boldLabel);

            customFieldStyle.padding.left = 0;
            customFieldStyle.padding.right = 5;
            customFieldStyle.alignment = TextAnchor.MiddleRight;

            EditorGUI.BeginChangeCheck();

            value = EditorGUI.IntField(settingsItemFieldRect, value, customFieldStyle);

            if (EditorGUI.EndChangeCheck())
            {
                if (value < min)
                {
                    value = min;
                }
                else if (value > max)
                {
                    value = max;
                }
            }

            UpdateRects();

            return value;
        }

        protected bool MakeSetting(string label, bool value)
        {
            MakeBox(settingsItemBoxRect);

            labelContentCache.text = label;
            labelContentCache.tooltip = label;
            GUI.Label(settingsItemNameRect, labelContentCache, EditorStyles.boldLabel);

            value = GUI.Toggle(settingsItemToggleRect, value, "");

            UpdateRects();

            return value;
        }
        protected string MakeSetting(string label, string value)
        {
            MakeBox(settingsItemBoxRect);

            labelContentCache.text = label;
            labelContentCache.tooltip = label;
            GUI.Label(settingsItemNameRect, labelContentCache, EditorStyles.boldLabel);

            customFieldStyle.padding.left = 5;
            customFieldStyle.padding.right = 0;
            customFieldStyle.alignment = TextAnchor.MiddleLeft;
            value = GUI.TextField(settingsItemFieldRect, value, customFieldStyle);

            UpdateRects();

            return value;
        }

        #endregion

        #region Panel Implementations

        protected override void MakeBoxes()
        {
            MakeBox(PanelBoxRect);
            MakeBox(HeaderBoxRect, Color.black);
            MakeBox(settingsMainRect);
        }

        #endregion

        #region IEditorSaveObject Implementations

        public bool Enabled
        {
            get;
            set;
        } = true;

        public abstract string ID
        {
            get;
        }

        public abstract void Reset();
        public abstract Map Serialize();
        public abstract void Serialize(Map map, bool overwrite);
        public abstract void Deserialize(Map map);

        #endregion
    }
}
