using System.Collections;
using UnityEngine;

namespace WiseMonkeES.Mover
{
    public class Rotate: Mover
    {
        
        public static void To(Transform transform, Vector3 target, float seconds, bool isLocal = false)
        {
            Instance.StartCoroutine(RotateTo(transform, target, seconds,isLocal));
        }

        private static IEnumerator RotateTo(Transform transform, Vector3 target, float seconds, bool isLocal)
        {
            StartAction();
            float elapsedTime = 0;
            Quaternion startingRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(target);

            while (elapsedTime < seconds)
            {
                if(isLocal)
                    transform.localRotation = Quaternion.Lerp(startingRotation, targetRotation, (elapsedTime / seconds));
                else
                    transform.rotation = Quaternion.Lerp(startingRotation, targetRotation, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            EndAction();
        }
        
        public static void Around(Transform transform, Vector3 targetPos, float degree, float seconds)
        {
                Instance.StartCoroutine(RotateAround(transform, targetPos, degree, Vector3.forward, seconds));
        }
        
        public static void Around(Transform transform, Vector3 targetPos, float degree,Vector3 axis, float seconds)
        {
            Instance.StartCoroutine(RotateAround(transform, targetPos, degree, axis, seconds));
        }
        
        private static IEnumerator RotateAround(Transform transform, Vector3 target, float degree, Vector3 axis, float seconds)
        {
            StartAction();
            float elapsedTime = 0;

            while (elapsedTime < seconds)
            {
                transform.RotateAround(target, axis, degree * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            EndAction();

        }
        
        
    }
}