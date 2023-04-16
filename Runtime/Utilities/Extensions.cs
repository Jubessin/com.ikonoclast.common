using System;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections.Generic;

using UnityTime = UnityEngine.Time;
using UnityObject = UnityEngine.Object;
using UnityRandom = UnityEngine.Random;

namespace Ikonoclast.Common
{
    public static class EnumExtensions
    {
        public static int GetSetBitCount(this Enum @enum)
        {
            if (@enum == null)
                return 0;

            int count = 0;

            long value = Convert.ToInt64(@enum);

            while (value != 0)
            {
                value &= (value - 1);

                count++;
            }

            return count;
        }
    }

    public static class StringExtensions
    {
        public static string UniquePath(this string str, string ext)
        {
            int i = 1;

            string temp = str.Replace(ext, "");

            while (File.Exists(str))
            {
                str = $"{temp} ({i++}){ext}";
            }

            return str;
        }

        public static bool Contains(this string str, string other, StringComparison comparison)
        {
            return str?.IndexOf(other, comparison) >= 0;
        }

        public static bool ContainsAny(this string str, params string[] strings)
        {
            if (strings == null)
                return false;

            for (int i = 0; i < strings.Length; i++)
                if (str.Contains(strings[i]))
                    return true;

            return false;
        }

        public static bool ContainsAny(this string str, string string1, string string2)
        {
            return str.Contains(string1) || str.Contains(string2);
        }

        public static bool ContainsAny(this string str, string string1, string string2, string string3)
        {
            return str.Contains(string1) || str.Contains(string2) || str.Contains(string3);
        }

        public static string ReplaceAll(this string s, string s1, string newValue) =>
            s.Replace(s1, newValue);

        public static string ReplaceAll(this string s, string s1, string s2, string newValue) =>
            s.Replace(s1, newValue).Replace(s2, newValue);

        public static string ReplaceAll(this string s, string s1, string s2, string s3, string newValue) =>
            s.Replace(s1, newValue).Replace(s2, newValue).Replace(s3, newValue);

        public static string ReplaceAll(this string s, string newValue, params string[] rep)
        {
            for (int i = 0; i < rep.Length; ++i)
            {
                s = s.Replace(rep[i], newValue);
            }

            return s;
        }
    }

    public static class QueueExtensions
    {
        public static T SafePeek<T>(this Queue<T> queue) =>
            queue.Count == 0 ? default : queue.Peek();

        public static T SafeDequeue<T>(this Queue<T> queue) =>
            queue.Count == 0 ? default : queue.Dequeue();
    }

    public static class HashSetExtensions
    {
        /// <summary>
        /// Add multiple values to a hashset.
        /// </summary>
        public static void AddRange<T>(this HashSet<T> hashset, IEnumerable<T> values)
        {
            if (hashset == null || values == null)
                return;

            foreach (var value in values)
            {
                hashset.Add(value);
            }
        }

        /// <summary>
        /// LINQ-extension method for HashSet, using .Any query.
        /// </summary>
        /// <param name="hashset"></param>
        /// <param name="actor"></param>
        /// <returns></returns>
        public static bool ContainsKey<TKey, TValue>(this HashSet<KeyValuePair<TKey, TValue>> hashset, TKey key) =>
            hashset.Any(x => x.Key.Equals(key));
    }

    public static class VectorExtensions
    {
        public static Vector2 Absolute(this Vector2 v2) =>
            new Vector2
            {
                x = Mathf.Abs(v2.x),
                y = Mathf.Abs(v2.y)
            };

        public static Vector3 Absolute(this Vector3 v3) =>
            new Vector3
            {
                x = Mathf.Abs(v3.x),
                y = Mathf.Abs(v3.y),
                z = Mathf.Abs(v3.z)
            };

        public static Vector2 VectorParse(string value)
        {
            var stringedVector = value.Substring(1, value.Length - 1 - 1);

            var stringedVectorValues = stringedVector.Split(',');

            System.Globalization.NumberStyles parseStyle =
                System.Globalization.NumberStyles.Float |
                System.Globalization.NumberStyles.AllowThousands;

            return new Vector2
            (
                float.Parse(stringedVectorValues[0], parseStyle),
                float.Parse(stringedVectorValues[1], parseStyle)
            );
        }

        /// <summary>
        /// Returns whether the distance between vectors is less than range.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <useful>
        /// 43.82 is the approximate sqrt of 1920 (laptop fullscreen width).
        /// 32.86 is the approximate sqrt of 1080 (laptop fullscreen height).
        /// </useful>
        public static bool InRange(this Vector2 a, Vector2 b, int range)
        {
            if (Mathf.Abs(a.x - b.x) > range || Mathf.Abs(a.y - b.y) > range)
                return false;

            return range << 2 > ((int)(a.x - b.x) << 2) + ((int)(a.y - b.y) << 2);
        }

        /// <summary>
        /// Returns whether the distance between vectors is less than range (precise).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <useful>
        /// 43.82 is the approximate sqrt of 1920 (not laptop fullscreen width).
        /// 32.86 is the approximate sqrt of 1080 (not laptop fullscreen height).
        /// </useful>
        public static bool InRange(this Vector2 a, Vector2 b, float range)
        {
            if (Mathf.Abs(a.x - b.x) > range || Mathf.Abs(a.y - b.y) > range)
                return false;

            return Mathf.Pow(range, 2) > Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2);
        }

        /// <summary>
        /// Returns whether the distance between vectors is less than range.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <useful>
        /// 43.82 is the approximate sqrt of 1920 (laptop fullscreen width).
        /// 32.86 is the approximate sqrt of 1080 (laptop fullscreen height).
        /// </useful>
        public static bool InRange(this Vector3 a, Vector3 b, int range) =>
            ((Vector2)a).InRange(b, range);

        /// <summary>
        /// Returns whether the distance between vectors is less than range (precise).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <useful>
        /// 43.82 is the approximate sqrt of 1920 (not laptop fullscreen width).
        /// 32.86 is the approximate sqrt of 1080 (not laptop fullscreen height).
        /// </useful>
        public static bool InRange(this Vector3 a, Vector3 b, float range) =>
            ((Vector2)a).InRange(b, range);
    }

    public static class TimeExtensions
    {
        private class Time : UnityTime
        {
            public static bool Elapsed(double cache, double interval)
            {
                return time - cache > interval;
            }
        }

        public static bool TimeElapsed(double timeCache, double timeInterval) =>
            Time.Elapsed(timeCache, timeInterval);
    }

    public static class RandomExtensions
    {
        /// <summary>
        /// Return a random integer number between min [inclusive] and max [exclusive], with exclusion.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="exclude">Number to exclude.</param>
        public static int XRange(int min, int max, int exclude)
        {
            int random = UnityRandom.Range(min, max);

            for (; exclude == random; random = UnityRandom.Range(min, max)) ;

            return random;
        }

        /// <summary>
        /// Return a random integer number between min [inclusive] and max [exclusive], with exclusion.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="exclude">Numbers to exclude.</param>
        /// <returns></returns>
        public static int XRange(int min, int max, HashSet<int> exclude)
        {
            int random = UnityRandom.Range(min, max);

            for (; exclude.Contains(random); random = UnityRandom.Range(min, max)) ;

            return random;
        }
    }

    public static class Texture2DExtensions
    {
        public static bool IsTransparent(this Texture2D tex, RectInt block)
        {
            if (tex == null)
                throw new ArgumentNullException(nameof(tex));

            var pixels = tex.GetPixels(block.x, block.y, block.width, block.height);

            for (int i = 0; i < pixels.Length; i++)
                if (pixels[i].a != 0)
                    return false;

            return true;
        }
    }

    public static class VisualElementExtensions
    {
        /// <summary>
        /// Sets the minimum width of the visual element's style.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="width"></param>
        public static void SetMinWidth(this VisualElement elem, float width)
        {
            elem.style.minWidth = width;
        }

        /// <summary>
        /// Sets the maximum width of the visual element's style.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="width"></param>
        public static void SetMaxWidth(this VisualElement elem, float width)
        {
            elem.style.maxWidth = width;
        }

        /// <summary>
        /// Sets the minimum height of the visual element's style.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="width"></param>
        public static void SetMinHeight(this VisualElement elem, float height)
        {
            elem.style.minHeight = height;
        }

        /// <summary>
        /// Sets the maximum height of the visual element's style.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="width"></param>
        public static void SetMaxHeight(this VisualElement elem, float height)
        {
            elem.style.maxHeight = height;
        }
    }

    public static class ComponentExtensions
    {
        public static int GetLayer(this Component component) =>
            component.gameObject.layer;

        public static bool DestroysOnLoad(this Component self)
        {
            if (self == null)
                throw new ArgumentNullException();

            return self.gameObject.scene.buildIndex != -1;
        }

        public static void GetOrThrow<T>(this Component self, ref T component) where T : Component
        {
            if (component != null)
                return;

            if (self == null)
                throw new ArgumentNullException(nameof(self));

            component = self.GetComponent<T>();

            if (component == null)
                throw new MissingComponentException(typeof(T).FullName);
        }

        public static bool TryGetComponentInParent<T>(this Component self, out T component, bool includeSelf = false)
        {
            component = default;

            if (self == null)
                return false;

            if (includeSelf && self.TryGetComponent(out component))
                return true;

            for (var parent = self.transform.parent; parent != null; parent = parent.parent)
                if (parent.TryGetComponent(out component))
                    return true;

            return false;
        }

        public static bool TryGetComponentInChildren<T>(this Component self, out T component, bool includeSelf = false)
        {
            component = default;

            if (self == null)
                return false;

            if (includeSelf && self.TryGetComponent(out component))
                return true;

            for (int i = 0; i < self.transform.childCount; ++i)
                if (self.transform.GetChild(i).TryGetComponentInChildren(out component, true))
                    return true;

            return false;
        }
    }

    public static class GameObjectExtensions
    {
        public static bool DestroysOnLoad(this GameObject self)
        {
            if (self == null)
                throw new ArgumentNullException();

            return self.scene.buildIndex != -1;
        }

        public static void SafeDestroy<T>(this GameObject gameObject) where T : UnityObject
        {
            if (gameObject == null)
                throw new ArgumentNullException(nameof(gameObject));

            if (!gameObject.TryGetComponent<T>(out var component))
            {
                Debug.LogWarning($"Unable to get component of type ({typeof(T)}) on GameObject ({gameObject}).");

                return;
            }

            if (Application.isPlaying)
            {
                UnityObject.Destroy(component);
            }
            else
            {
                UnityObject.DestroyImmediate(component);
            }

            Debug.LogWarning($"Removed component of type ({typeof(T)}) from GameObject ({gameObject})");
        }

        public static void SafeDestroy(this GameObject gameObject, Type type)
        {
            if (gameObject == null)
                throw new ArgumentNullException(nameof(gameObject));

            if (!gameObject.TryGetComponent(type, out var component))
            {
                Debug.LogWarning($"Unable to get component of type ({type}) on GameObject ({gameObject}).");

                return;
            }

            if (Application.isPlaying)
            {
                UnityObject.Destroy(component);
            }
            else
            {
                UnityObject.DestroyImmediate(component);
            }

            Debug.LogWarning($"Removed component of type ({type}) from GameObject ({gameObject})");
        }

        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T component, bool includeSelf = false)
        {
            component = default;

            if (gameObject == null)
                return false;

            if (includeSelf && gameObject.TryGetComponent(out component))
                return true;

            for (var parent = gameObject.transform.parent; parent != null; parent = parent.parent)
                if (parent.TryGetComponent(out component))
                    return true;

            return false;
        }

        public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T component, bool includeSelf = false)
        {
            component = default;

            if (gameObject == null)
                return false;

            if (includeSelf && gameObject.TryGetComponent(out component))
                return true;

            for (int i = 0; i < gameObject.transform.childCount; ++i)
                if (gameObject.transform.GetChild(i).TryGetComponentInChildren(out component, true))
                    return true;

            return false;
        }
    }

    public static class ObjectExtensions
    {
        public static T FindObjectOfType<T>(string name)
        {
            var obj = GameObject.Find(name);

            return obj == null || !obj.TryGetComponent<T>(out var component)
                ? default
                : component;
        }
    }
}
