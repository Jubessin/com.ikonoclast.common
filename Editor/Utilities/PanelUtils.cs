using UnityEditor;
using UnityEngine;

namespace Ikonoclast.Common.Editor
{
    using static CustomEditorHelper;

    public static class PanelUtils
    {
        private static GUIStyle _baseStyle = null;
        private static GUIStyle _titleStyle = null;
        private static GUIStyle _textFieldStyle = null;

        public static GUIStyle BaseStyle
        {
            get
            {
                if (_baseStyle == null)
                {
                    _baseStyle = new GUIStyle
                    {
                        clipping = TextClipping.Clip
                    };

                    _baseStyle.normal.textColor = Color.white;
                }

                return _baseStyle;
            }
        }
        public static GUIStyle TitleStyle
        {
            get
            {
                if (_titleStyle == null)
                {
                    _titleStyle = new GUIStyle(BaseStyle)
                    {
                        fontSize = 16,
                        alignment = TextAnchor.MiddleLeft
                    };

                    _titleStyle.padding.left = 10;
                }

                return _titleStyle;
            }
        }
        public static GUIStyle TextFieldStyle
        {
            get
            {
                if (_textFieldStyle == null)
                {
                    _textFieldStyle = new GUIStyle(BaseStyle);

                    _textFieldStyle.fontSize = 12;
                    _textFieldStyle.normal.textColor = Color.white;
                    _textFieldStyle.alignment = TextAnchor.MiddleLeft;
                    _textFieldStyle.normal.background = MakeTexture(new Color(0.16f, 0.16f, 0.16f));
                }

                return _textFieldStyle;
            }
        }

        public static void MakeBox(Rect rect)
        {
            GUI.Box(rect, GUIContent.none, EditorStyles.helpBox);
        }

        public static void MakeBox(Rect rect, Color color)
        {
            GUI.color = color;

            GUI.Box(rect, GUIContent.none, EditorStyles.helpBox);

            ResetGUIColor();
        }

        /// <summary>
        /// Makes a foldout that highlights when hovered.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="foldout"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool HoverFoldout(Rect rect, bool foldout, string text)
        {
            Event evt = Event.current;

            if (evt != null && rect.Contains(evt.mousePosition))
            {
                GUI.color = Color.white;
            }
            else
            {
                GUI.color = new Color(0.8f, 0.8f, 0.8f, 1);
            }

            bool ret = EditorGUI.Foldout(rect, foldout, text);

            ResetGUIColor();

            return ret;
        }
    }
}
