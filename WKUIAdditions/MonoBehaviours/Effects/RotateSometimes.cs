using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace WKUIAdditions.MonoBehaviours.Effects
{
    public class RotateSometimes : MonoBehaviour
    {
        public float duration = 2.5f;
        public Ease ease = Ease.InOutBack;

        bool isReverse;

        public IEnumerator Start()
        {
            while (true)
            {
                transform.DOLocalRotate(new Vector3(0, 0, isReverse ? 360 : 0), duration, RotateMode.LocalAxisAdd).SetEase(ease);

                isReverse = !isReverse;
                yield return new WaitForSeconds(Random.Range(10, 30));
            }
        }
    }
}
