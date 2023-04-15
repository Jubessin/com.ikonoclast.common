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
            _recordOffCache,
            _collabEditCache,
            _playButtonCache,
            _folderEmptyCache,
            _pauseButtonCache,
            _dropdownIconCache,
            _folderOpenedCache,
            _createAddNewCache,
            _favoriteIconCache,
            _dotSelectionCache,
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

        public static GUIContent Help =>
            _helpCache ??= EditorGUIUtility.IconContent("d__Help");

        public static GUIContent CreateAddNew =>
            _createAddNewCache ??= EditorGUIUtility.IconContent("CreateAddNew");

        public static GUIContent Close =>
            _closeCache ??= EditorGUIUtility.IconContent("winbtn_win_close");

        public static GUIContent Search =>
            _searchCache ??= EditorGUIUtility.IconContent("Search Icon");

        public static GUIContent Project =>
            _projectCache ??= EditorGUIUtility.IconContent("Project");

        public static GUIContent NextTab =>
            _nextTabCache ??= EditorGUIUtility.IconContent("tab_next");

        public static GUIContent PrevTab =>
            _prevTabCache ??= EditorGUIUtility.IconContent("tab_prev");

        public static GUIContent Refresh =>
            _refreshCache ??= EditorGUIUtility.IconContent("refresh");

        public static GUIContent Menu =>
            _menuCache ??= EditorGUIUtility.IconContent("_Menu");

        public static GUIContent Back =>
            _backCache ??= EditorGUIUtility.IconContent("back");

        public static GUIContent Forward =>
            _forwardCache ??= EditorGUIUtility.IconContent("forward");

        public static GUIContent Settings =>
            _settingsCache ??= EditorGUIUtility.IconContent("d_Settings");

        public static GUIContent CollabEdit =>
            _collabEditCache ??= EditorGUIUtility.IconContent("CollabEdit Icon");

        public static GUIContent BlendTree =>
            _blendTreeCache ??= EditorGUIUtility.IconContent("d_BlendTree Icon");

        public static GUIContent RecordOff =>
            _recordOffCache ??= EditorGUIUtility.IconContent("d_Record Off");

        public static GUIContent DotSelection =>
            _dotSelectionCache ??= EditorGUIUtility.IconContent("DotSelection");

        public static GUIContent Align_Vertically_Center_Active =>
            _align_Vertically_Center_ActiveCache ??= EditorGUIUtility.IconContent("d_align_vertically_center_active");

        public static GUIContent Warn =>
            _warnCache ??= EditorGUIUtility.IconContent("console.warnicon");

        public static GUIContent ScriptableObject =>
            _scriptableObjectCache ??= EditorGUIUtility.IconContent("d_ScriptableObject Icon");

        public static GUIContent ScriptableObjectOn =>
            _scriptableObjectOnCache ??= EditorGUIUtility.IconContent("d_ScriptableObject On Icon");

        public static GUIContent Prefab =>
            _prefabCache ??= EditorGUIUtility.IconContent("d_Prefab Icon");

        public static GUIContent Folder =>
            _folderCache ??= EditorGUIUtility.IconContent("d_Folder Icon");

        public static GUIContent FolderEmpty =>
            _folderEmptyCache ??= EditorGUIUtility.IconContent("d_FolderEmpty Icon");

        public static GUIContent FolderOpened =>
            _folderOpenedCache ??= EditorGUIUtility.IconContent("d_FolderOpened Icon");

        public static GUIContent SaveAs =>
            _saveAsCache ??= EditorGUIUtility.IconContent("d_SaveAs");

        public static GUIContent EventTrigger =>
            _eventTriggerCache ??= EditorGUIUtility.IconContent("d_EventTrigger Icon");

        public static GUIContent ConsoleWindow =>
            _consoleWindowCache ??= EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow");

        public static GUIContent FavoriteIcon =>
            _favoriteIconCache ??= EditorGUIUtility.IconContent("d_Favorite Icon");

        public static GUIContent FavoriteOnIcon =>
            _favoriteOnIconCache ??= EditorGUIUtility.IconContent("d_Favorite On Icon");

        public static GUIContent P4_Conflicted =>
            _p4_ConflictedCache ??= EditorGUIUtility.IconContent("P4_Conflicted");

        public static GUIContent P4_CheckOutLocal =>
            _p4_CheckOutLocalCache ??= EditorGUIUtility.IconContent("P4_CheckOutLocal");

        public static GUIContent PlayButton =>
            _playButtonCache ??= EditorGUIUtility.IconContent("d_PlayButton");

        public static GUIContent PauseButton =>
            _pauseButtonCache ??= EditorGUIUtility.IconContent("d_PauseButton");

        public static GUIContent InspectorWindow =>
            _inspectorWindowCache ??= EditorGUIUtility.IconContent("d_UnityEditor.InspectorWindow");

        public static GUIContent TextMeshIcon =>
            _textMeshIconCache ??= EditorGUIUtility.IconContent("TextMesh Icon");

        public static GUIContent VerticalLayoutGroupIcon =>
            _verticalLayoutGroupIconCache ??= EditorGUIUtility.IconContent("d_VerticalLayoutGroup Icon");

        public static GUIContent AnimationClipIcon =>
            _animationClipIconCache ??= EditorGUIUtility.IconContent("d_AnimationClip Icon");

        public static GUIContent DropdownIcon =>
            _dropdownIconCache ??= EditorGUIUtility.IconContent("d_icon dropdown");

        public static GUIContent UpArrow =>
            _upArrowCache ??= EditorGUIUtility.IconContent("UpArrow");
    }
}