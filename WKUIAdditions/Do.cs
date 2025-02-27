using DG.Tweening;
using DG.Tweening.Plugins;
using UnityEngine;

namespace WKUIAdditions
{
    // feel free to take it lol.
    public static class Do
    {
        #region Rect Anchoring
        public static void SetAnc(Vector2 pos, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.anchoredPosition = pos;
            }
        }

        public static void AddAnc(Vector2 pos, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.anchoredPosition += pos;
            }
        }

        public static void SetAncX(float pos, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.anchoredPosition = new Vector2(pos, rect.anchoredPosition.y);
            }
        }

        public static void AddAncX(float pos, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + pos, rect.anchoredPosition.y);
            }
        }

        public static void SetAncY(float pos, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, pos);
            }
        }
        public static void AddAncY(float pos, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + pos);
            }
        }

        public static void AncX(string path, float endPos, float duration, Ease ease = Ease.Linear)
        {
            if (!TryGetRect(path, out RectTransform rect)) return;

            rect.DOAnchorPosX(endPos, duration).SetEase(ease);

            return;
        }
        #endregion

        #region Rect Pivot
        public static void SetPivot(Vector2 pivot, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.pivot = pivot;
            }
        }

        public static void AddPivot(Vector2 pivot, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.pivot += pivot;
            }
        }

        public static void AddPivotX(float pivot, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.pivot = new Vector2(rect.pivot.x + pivot, rect.pivot.y);
            }
        }

        public static void AddPivotY(float pivot, params string[] path)
        {
            foreach (string s in path)
            {
                if (!TryGetRect(s, out RectTransform rect)) continue;

                rect.pivot = new Vector2(rect.pivot.x, rect.pivot.y + pivot);
            }
        }

        public static void DoPivotX(string path, float endPos, float duration, Ease ease = Ease.Linear)
        {
            if (!TryGetRect(path, out RectTransform rect)) return;

            rect.DOPivotX(endPos, duration).SetEase(ease);
        }

        public static void DoPivotY(string path, float endPos, float duration, Ease ease = Ease.Linear)
        {
            if (!TryGetRect(path, out RectTransform rect)) return;

            rect.DOPivotY(endPos, duration).SetEase(ease);
        }

        public static void DoPivot(string path, Vector2 endPos, float duration, Ease ease = Ease.Linear)
        {
            if (!TryGetRect(path, out RectTransform rect)) return;

            rect.DOPivot(endPos, duration).SetEase(ease);
        }
        #endregion

        public static bool TryGetRect(string path, out RectTransform rect)
        {
            rect = null;

            GameObject obj = GameObject.Find(path);

            if (obj == null) return false;

            rect = obj.GetComponent<RectTransform>();

            return rect != null;
        }
    }
}
