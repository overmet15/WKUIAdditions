using DG.Tweening;
using DG.Tweening.Plugins;
using UnityEngine;

namespace WKUIAdditions
{
    // feel free to take it too.
    public static class If
    {
        public static bool Exists(string path, out GameObject gameObject)
        {
            gameObject = GameObject.Find(path);

            if (gameObject == null)
                Debug.Log(path);

            return gameObject != null;
        }

        public static bool Exists<T>(string path, out T result) where T : Component
        {
            result = null;

            GameObject gameObject = GameObject.Find(path);

            if (gameObject == null) return false;

            result = gameObject.GetComponent<T>();

            if (result == null)
            {
                Debug.Log(path);
            }

            return result != null;
        }
    }
}
