using UnityEditor;
using UnityEngine;

namespace Ikonoclast.Common.Editor
{
    public sealed class UnityIcons
    {
        private static GUIContent
            _helpCache,
            _warnCache,
            _backCache,
            _menuCache,
            _closeCache,
            _prefabCache,
            _searchCache,
            _saveAsCache,
            _folderCache,
            _projectCache,
            _nextTabCache,
            _prevTabCache,
            _refreshCache,
            _forwardCache,
            _upArrowCache,
            _settingsCache,
            _blendTreeCache,
            _collabEditCache,
            _playButtonCache,
            _folderEmptyCache,
            _pauseButtonCache,
            _dropdownIconCache,
            _folderOpenedCache,
            _createAddNewCache,
            _favoriteIconCache,
            _textMeshIconCache,
            _eventTriggerCache,
            _p4_ConflictedCache,
            _consoleWindowCache,
            _favoriteOnIconCache,
            _inspectorWindowCache,
            _p4_CheckOutLocalCache,
            _scriptableObjectCache,
            _animationClipIconCache,
            _scriptableObjectOnCache,
            _verticalLayoutGroupIconCache,
            _align_Vertically_Center_ActiveCache;

        public static GUIContent Help
        {
            get
            {
                if (_helpCache == null)
                {
                    _helpCache = EditorGUIUtility.IconContent("d__Help");
                }

                return _helpCache;
            }
        }

        public static GUIContent CreateAddNew
        {
            get
            {
                if (_createAddNewCache == null)
                {
                    _createAddNewCache = EditorGUIUtility.IconContent("CreateAddNew");
                }

                return _createAddNewCache;
            }
        }

        public static GUIContent Close
        {
            get
            {
                if (_closeCache == null)
                {
                    _closeCache = EditorGUIUtility.IconContent("winbtn_win_close");
                }

                return _closeCache;
            }
        }

        public static GUIContent Search
        {
            get
            {
                if (_searchCache == null)
                {
                    _searchCache = EditorGUIUtility.IconContent("Search Icon");
                }

                return _searchCache;
            }
        }

        public static GUIContent Project
        {
            get
            {
                if (_projectCache == null)
                {
                    _projectCache = EditorGUIUtility.IconContent("Project");
                }

                return _projectCache;
            }
        }

        public static GUIContent NextTab
        {
            get
            {
                if (_nextTabCache == null)
                {
                    _nextTabCache = EditorGUIUtility.IconContent("tab_next");
                }

                return _nextTabCache;
            }
        }

        public static GUIContent PrevTab
        {
            get
            {
                if (_prevTabCache == null)
                {
                    _prevTabCache = EditorGUIUtility.IconContent("tab_prev");
                }

                return _prevTabCache;
            }
        }

        public static GUIContent Refresh
        {
            get
            {
                if (_refreshCache == null)
                {
                    _refreshCache = EditorGUIUtility.IconContent("refresh");
                }

                return _refreshCache;
            }
        }

        public static GUIContent Menu
        {
            get
            {
                if (_menuCache == null)
                {
                    _menuCache = EditorGUIUtility.IconContent("_Menu");
                }

                return _menuCache;
            }
        }

        public static GUIContent Back
        {
            get
            {
                if (_backCache == null)
                {
                    _backCache = EditorGUIUtility.IconContent("back");
                }

                return _backCache;
            }
        }

        public static GUIContent Forward
        {
            get
            {
                if (_forwardCache == null)
                {
                    _forwardCache = EditorGUIUtility.IconContent("forward");
                }

                return _forwardCache;
            }
        }

        public static GUIContent Settings
        {
            get
            {
                if (_settingsCache == null)
                {
                    _settingsCache = EditorGUIUtility.IconContent("d_Settings");
                }

                return _settingsCache;
            }
        }

        public static GUIContent CollabEdit
        {
            get
            {
                if (_collabEditCache == null)
                {
                    _collabEditCache = EditorGUIUtility.IconContent("CollabEdit Icon");
                }

                return _collabEditCache;
            }
        }

        public static GUIContent BlendTree
        {
            get
            {
                if (_blendTreeCache == null)
                {
                    _blendTreeCache = EditorGUIUtility.IconContent("d_BlendTree Icon");
                }

                return _blendTreeCache;
            }
        }

        public static GUIContent Align_Vertically_Center_Active
        {
            get
            {
                if (_align_Vertically_Center_ActiveCache == null)
                {
                    _align_Vertically_Center_ActiveCache = EditorGUIUtility.IconContent("d_align_vertically_center_active");
                }

                return _align_Vertically_Center_ActiveCache;
            }
        }

        public static GUIContent Warn
        {
            get
            {
                if (_warnCache == null)
                {
                    _warnCache = EditorGUIUtility.IconContent("console.warnicon");
                }

                return _warnCache;
            }
        }

        public static GUIContent ScriptableObject
        {
            get
            {
                if (_scriptableObjectCache == null)
                {
                    _scriptableObjectCache = EditorGUIUtility.IconContent("d_ScriptableObject Icon");
                }

                return _scriptableObjectCache;
            }
        }

        public static GUIContent ScriptableObjectOn
        {
            get
            {
                if (_scriptableObjectOnCache == null)
                {
                    _scriptableObjectOnCache = EditorGUIUtility.IconContent("d_ScriptableObject On Icon");
                }

                return _scriptableObjectOnCache;
            }
        }

        public static GUIContent Prefab
        {
            get
            {
                if (_prefabCache == null)
                {
                    _prefabCache = EditorGUIUtility.IconContent("d_Prefab Icon");
                }

                return _prefabCache;
            }
        }

        public static GUIContent Folder
        {
            get
            {
                if (_folderCache == null)
                {
                    _folderCache = EditorGUIUtility.IconContent("d_Folder Icon");
                }

                return _folderCache;
            }
        }

        public static GUIContent FolderEmpty
        {
            get
            {
                if (_folderEmptyCache == null)
                {
                    _folderEmptyCache = EditorGUIUtility.IconContent("d_FolderEmpty Icon");
                }

                return _folderEmptyCache;
            }
        }

        public static GUIContent FolderOpened
        {
            get
            {
                if (_folderOpenedCache == null)
                {
                    _folderOpenedCache = EditorGUIUtility.IconContent("d_FolderOpened Icon");
                }

                return _folderOpenedCache;
            }
        }

        public static GUIContent SaveAs
        {
            get
            {
                if (_saveAsCache == null)
                {
                    _saveAsCache = EditorGUIUtility.IconContent("d_SaveAs");
                }

                return _saveAsCache;
            }
        }

        public static GUIContent EventTrigger
        {
            get
            {
                if (_eventTriggerCache == null)
                {
                    _eventTriggerCache = EditorGUIUtility.IconContent("d_EventTrigger Icon");
                }

                return _eventTriggerCache;
            }
        }

        public static GUIContent ConsoleWindow
        {
            get
            {
                if (_consoleWindowCache == null)
                {
                    _consoleWindowCache = EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow");
                }

                return _consoleWindowCache;
            }
        }

        public static GUIContent FavoriteIcon
        {
            get
            {
                if (_favoriteIconCache == null)
                {
                    _favoriteIconCache = EditorGUIUtility.IconContent("d_Favorite Icon");
                }

                return _favoriteIconCache;
            }
        }

        public static GUIContent FavoriteOnIcon
        {
            get
            {
                if (_favoriteOnIconCache == null)
                {
                    _favoriteOnIconCache = EditorGUIUtility.IconContent("d_Favorite On Icon");
                }

                return _favoriteOnIconCache;
            }

        }

        public static GUIContent P4_Conflicted
        {
            get
            {
                if (_p4_ConflictedCache == null)
                {
                    _p4_ConflictedCache = EditorGUIUtility.IconContent("P4_Conflicted");
                }

                return _p4_ConflictedCache;
            }
        }

        public static GUIContent P4_CheckOutLocal
        {
            get
            {
                if (_p4_CheckOutLocalCache == null)
                {
                    _p4_CheckOutLocalCache = EditorGUIUtility.IconContent("P4_CheckOutLocal");
                }

                return _p4_CheckOutLocalCache;
            }
        }

        public static GUIContent PlayButton
        {
            get
            {
                if (_playButtonCache == null)
                {
                    _playButtonCache = EditorGUIUtility.IconContent("d_PlayButton");
                }

                return _playButtonCache;
            }
        }

        public static GUIContent PauseButton
        {
            get
            {
                if (_pauseButtonCache == null)
                {
                    _pauseButtonCache = EditorGUIUtility.IconContent("d_PauseButton");
                }

                return _pauseButtonCache;
            }
        }

        public static GUIContent InspectorWindow
        {
            get
            {
                if (_inspectorWindowCache == null)
                {
                    _inspectorWindowCache = EditorGUIUtility.IconContent("d_UnityEditor.InspectorWindow");
                }

                return _inspectorWindowCache;
            }
        }

        public static GUIContent TextMeshIcon
        {
            get
            {
                if (_textMeshIconCache == null)
                {
                    _textMeshIconCache = EditorGUIUtility.IconContent("TextMesh Icon");
                }

                return _textMeshIconCache;
            }
        }

        public static GUIContent VerticalLayoutGroupIcon
        {
            get
            {
                if (_verticalLayoutGroupIconCache == null)
                {
                    _verticalLayoutGroupIconCache = EditorGUIUtility.IconContent("d_VerticalLayoutGroup Icon");
                }

                return _verticalLayoutGroupIconCache;
            }
        }

        public static GUIContent AnimationClipIcon
        {
            get
            {
                if (_animationClipIconCache == null)
                {
                    _animationClipIconCache = EditorGUIUtility.IconContent("d_AnimationClip Icon");
                }

                return _animationClipIconCache;
            }
        }

        public static GUIContent DropdownIcon
        {
            get
            {
                if (_dropdownIconCache == null)
                {
                    _dropdownIconCache = EditorGUIUtility.IconContent("d_icon dropdown");
                }

                return _dropdownIconCache;
            }
        }

        public static GUIContent UpArrow
        {
            get
            {
                if (_upArrowCache == null)
                {
                    _upArrowCache = EditorGUIUtility.IconContent("UpArrow");
                }

                return _upArrowCache;
            }
        }
    }
}