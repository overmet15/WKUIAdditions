using UnityEngine;
using System.Collections;
using DG.Tweening;
using BepInEx;
using UnityEngine.Windows;
using UnityEngine.EventSystems;

namespace WKUIAdditions.MonoBehaviours.Effects
{
    public class ShakeNearCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        bool enter;

        void Update()
        {
            if (enter) transform.rotation = Quaternion.Euler(0, 0, Random.Range(-2.5f, 2.5f));
            else transform.rotation = Quaternion.identity;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            enter = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            enter = false;
        }
    }
}
