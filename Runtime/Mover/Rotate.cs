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
        
        public static void Around(Transform transform, Vector3 target, float degree, float seconds)
        {
                Instance.StartCoroutine(RotateAround(transform, target, degree, seconds));
        }
        
        private static IEnumerator RotateAround(Transform transform, Vector3 target, float degree, float seconds)
        {
            //rotate around target using transform.rotateAround and lerp
            StartAction();
            float elapsedTime = 0;

            Vector3 axis = Vector3.forward;

            
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