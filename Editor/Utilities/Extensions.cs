
#if UNITY_EDITOR
using UnityEditor;
#endif

using System;
using System.Collections.Generic;
using UnityObject = UnityEngine.Object;

namespace Ikonoclast.Common.Editor
{
    public static class AssetDatabaseExtensions
    {
        public static bool AssetExists<T>() where T : UnityObject
        {
            string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T)));

            for (int j = 0; j < guids.Length; j++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[j]);

                if (AssetDatabase.LoadAssetAtPath<T>(assetPath) != null)
                    return true;
            }

            return false;
        }

        public static bool AssetExists(Type type)
        {
            string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", type));

            for (int j = 0; j < guids.Length; j++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[j]);

                if (AssetDatabase.LoadAssetAtPath(assetPath, type) != null)
                    return true;
            }

            return false;
        }

        public static IList<T> FindAssetsOfType<T>(string filter, string[] searchInFolders = null) where T : UnityObject
        {
            string[] guids;

            if (searchInFolders == null)
            {
                guids = AssetDatabase.FindAssets(filter);
            }
            else
            {
                guids = AssetDatabase.FindAssets(filter, searchInFolders);
            }

            IList<T> list = new List<T>();

            for (int i = 0; i < guids.Length; ++i)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);

                if (string.IsNullOrWhiteSpace(assetPath))
                    continue;

                list.Add(AssetDatabase.LoadAssetAtPath<T>(assetPath));
            }

            return list;
        }
    }
}