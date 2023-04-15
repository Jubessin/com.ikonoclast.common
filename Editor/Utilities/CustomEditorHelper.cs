using System;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

using UnityObject = UnityEngine.Object;

namespace Ikonoclast.Common.Editor
{
    public static class CustomEditorHelper
    {
        public const int
            LEFT_CLICK = 0,
            RIGHT_CLICK = 1;

        /// <summary>
        /// Context menu item.
        /// </summary>
        public struct CTXMenu_Item
        {
            public bool On
            {
                get;
                private set;
            }

            public bool Separator
            {
                get;
                private set;
            }

            public GUIContent Content
            {
                get;
                private set;
            }

            public GenericMenu.MenuFunction MenuFunction
            {
                get;
                private set;
            }

            /// <param name="on">Adds a check mark if true.</param>
            public CTXMenu_Item(string content, bool on, GenericMenu.MenuFunction func, bool separator = false)
            {
                if (content == null || func == null)
                    throw new Exception("CTXMenu_Item does not accept null arguments.");

                On = on;
                MenuFunction = func;
                Separator = separator;
                Content = new GUIContent(content);
            }

            /// <param name="on">Adds a check mark if true.</param>
            public CTXMenu_Item(GUIContent content, bool on, GenericMenu.MenuFunction func, bool separator = false)
            {
                if (content == null || func == null)
                    throw new Exception("CTXMenu_Item does not accept null arguments.");

                On = on;
                Content = content;
                MenuFunction = func;
                Separator = separator;
            }
        }

        #region Fields

        private static readonly HashSet<int>
            sessionIDs = new HashSet<int>();

        /// <summary>
        /// Default single line distance.
        /// </summary>
        public static readonly float slh = EditorGUIUtility.singleLineHeight;

        public static readonly Color inspColor = new Color(0.22f, 0.22f, 0.22f);

        public static readonly Color helpBoxColor = new Color(0.25f, 0.25f, 0.25f);

        private static Color?
            defaultGUIColor = null,
            defaultGUIContentColor = null;

        #endregion

        #region Properties

        public static GUIStyle GenericTitleStyle
        {
            get
            {
                var gs = new GUIStyle()
                {
                    fontSize = 18,
                    fontStyle = FontStyle.BoldAndItalic,
                };

                gs.normal.textColor = new Color(0.8f, 0.8f, 0.8f);

                return gs;
            }
        }

        public static GUIStyle GenericButtonStyle
        {
            get
            {
                var gs = new GUIStyle()
                {
                    fontSize = 14,
                    fontStyle = FontStyle.Normal
                };

                gs.normal.textColor = new Color(0.8f, 0.8f, 0.8f);

                return gs;
            }
        }

        public static Vector2 ScreenMousePosition
        {
            get
            {
                var evt = Event.current;

                if (evt == null)
                {
                    Debug.LogWarning("Null event");
                    return Vector2.zero;
                }

                return GUIUtility.GUIToScreenPoint(evt.mousePosition);
            }
        }

        #endregion

        #region Methods

        public static void ResetGUIColor()
        {
            if (defaultGUIColor == null)
            {
                defaultGUIColor = GUI.color;

                Debug.LogWarning($"{nameof(GUI)}.{nameof(GUI.color)} not set before reset.");
            }

            GUI.color = defaultGUIColor.Value;
        }

        public static void ResetGUIContentColor()
        {
            if (defaultGUIContentColor == null)
            {
                defaultGUIContentColor = GUI.contentColor;

                Debug.LogWarning($"{nameof(GUI)}.{nameof(GUI.contentColor)} not set before reset.");
            }

            GUI.contentColor = defaultGUIContentColor.Value;
        }

        public static bool IsPrefab(Component cm) => cm
            ? PrefabUtility.GetCorrespondingObjectFromSource(cm) != null
            : false;

        public static bool IsPrefab(GameObject go) => go
            ? PrefabUtility.GetCorrespondingObjectFromSource(go) != null
            : false;

        public static int GenerateUniqueSessionID()
        {
            int uniqueID = UnityEngine.Random.Range(1, int.MaxValue);

            for (; !sessionIDs.Add(uniqueID); uniqueID = UnityEngine.Random.Range(1, int.MaxValue)) ;

            sessionIDs.Add(uniqueID);

            return uniqueID;
        }

        public static void ShowObjectPicker<T>(
            out int id,
            T selected = null,
            bool allowSceneObjects = false,
            string searchFilter = null) where T : UnityObject
        {
            EditorGUIUtility.ShowObjectPicker<T>(
                obj: selected,
                searchFilter: searchFilter,
                allowSceneObjects: allowSceneObjects,
                controlID: id = GUIUtility.GetControlID(FocusType.Passive) + 100);
        }

        public static bool HasObjectPickerClosed(int id) =>
            Event.current?.commandName == "ObjectSelectorClosed"
            && EditorGUIUtility.GetObjectPickerControlID() == id;

        /// <summary>
        /// Pings an asset in the project folder.
        /// </summary>
        /// <param name="obj">The object to ping.</param>
        public static void FocusAndPing(UnityObject obj)
        {
            if (obj == null)
                return;

            EditorUtility.FocusProjectWindow();
            EditorGUIUtility.PingObject(obj);
        }

        /// <summary>
        /// Pings an asset in the project folder.
        /// </summary>
        /// <param name="name">The name of the asset.</param>
        /// <param name="folders"></param>
        public static void FocusAndPing(string name, string[] folders)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            var strings = AssetDatabase.FindAssets(name, folders);

            if (strings.Length == 0)
                return;

            var path = AssetDatabase.GUIDToAssetPath(strings[0]);

            if (string.IsNullOrWhiteSpace(path))
                return;

            var asset = AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset));

            if (asset == null)
                return;

            EditorGUIUtility.PingObject(asset);
        }

        /// <summary>
        /// Attempts to find a type in assemblies by name, and returns a new instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Name of a class, object, or asset.</param>
        /// <returns>A new instantiated object, or null.</returns>
        public static T GetInstance<T>(string name)
        {
            var type = Type.GetType(name);

            T instance = default;

            if (type != null)
            {
                instance = (T)Activator.CreateInstance(type);

                if (instance != null)
                    return instance;
            }

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetTypes()?.FirstOrDefault(t => t.Name == name);

                if (type != null)
                {
                    try
                    {
                        instance = (T)Activator.CreateInstance(type);
                    }
                    catch (InvalidCastException) { }

                    if (instance != null)
                        return instance;
                }
            }

            return instance;
        }

        public static T GetComponentBySelection<T>() => Selection.activeGameObject
            ? Selection.activeGameObject.GetComponent<T>()
            : default;

        public static Texture2D MakeTexture(Color color)
        {
            var tx = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            tx.SetPixel(0, 0, color);
            tx.Apply();

            return tx;
        }

        public static void RepaintWindow(string typeName)
        {
            var windows = Resources.FindObjectsOfTypeAll<EditorWindow>();

            for (int i = 0; i < windows.Length; i++)
            {
                var window = windows[i];

                if (window.GetType().Name == typeName)
                {
                    window.Repaint();

                    break;
                }
            }
        }

        public static void SetDefaultGUIColor(Color? value)
        {
            if (defaultGUIColor == null)
            {
                defaultGUIColor = value;
            }
        }

        public static void SetDefaultGUIContentColor(Color? value)
        {
            if (defaultGUIContentColor == null)
            {
                defaultGUIContentColor = value;
            }
        }

        /// <summary>
        /// Creates and draws a context menu with the provided items.
        /// </summary>
        /// <param name="items"></param>
        public static void CreateContextMenu(CTXMenu_Item[] items)
        {
            if (items == null)
                return;

            var menu = new GenericMenu();

            foreach (var item in items)
            {
                menu.AddItem(item.Content, item.On, item.MenuFunction);

                if (item.Separator)
                {
                    menu.AddSeparator("");
                }
            }

            menu.ShowAsContext();
        }

        public static void AdjustRect(ref Rect rect, float x, float y, float width, float height)
        {
            rect.x = x;
            rect.y = y;
            rect.width = width;
            rect.height = height;
        }

        /// <summary>
        /// Draws a horizontal line on the editor window, in respect to the provided rect.
        /// </summary>
        /// <param name="_rect">The Rect to use as reference.</param>
        /// <param name="offsetX">The horizontal offset from the rect.</param>
        /// <param name="offsetY">The vertical offset from the rect.</param>
        /// <summary>
        /// Attempts to get a component of type T, from the selected GameObject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A component of type T, or null.</returns>
        public static void HGUILine(Rect _rect, float offsetX = 0, float offsetY = 1.1f, int lineHeight = 1)
        {
            var control = EditorGUILayout.GetControlRect(false, lineHeight);

            if (control == null)
                return;

            control.position = new Vector2(control.x + offsetX, _rect.y + offsetY);

            control.height = lineHeight;

            EditorGUI.DrawRect(control, new Color(0.5f, 0.5f, 0.5f, 1));
        }

        /// <summary>
        /// Draws a vertical line on the editor window, in respect to the provided rect.
        /// </summary>
        /// <param name="r">The Rect to use as reference.</param>
        /// <param name="lineHeight"></param>
        /// <param name="offsetX">Horizontal offset from the rect.</param>
        /// <param name="offsetY">Vertical offset from the rect.</param>
        /// <param name="lineWidth"></param>
        public static void VGUILine(Rect r, float lineHeight, float offsetX = 1.0f, float offsetY = 0, int lineWidth = 1)
        {
            var rect = EditorGUILayout.GetControlRect(false);

            if (rect == null)
                return;

            rect.position = new Vector2(rect.x + offsetX, r.y + offsetY);

            rect.width = lineWidth;
            rect.height = lineHeight;

            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }

        public static void IconButton(Rect position, Action buttonAction, GUIContent icon, string tooltip = null)
        {
            if (GUI.Button(position, new GUIContent("", tooltip ?? "")))
            {
                buttonAction?.Invoke();
            }

            GUI.Label(position, icon);
        }

        public static void IconButton(Rect position, Rect iconPosition, Action buttonAction, GUIContent icon, string tooltip = null)
        {
            if (GUI.Button(position, new GUIContent("", tooltip ?? "")))
            {
                buttonAction?.Invoke();
            }

            GUI.Label(iconPosition, icon);
        }

        #endregion
    }
}
