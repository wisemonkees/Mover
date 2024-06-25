using System.Collections;
using UnityEngine;

namespace WiseMonkeES.Mover
{
    public class Move: Mover
    {
        public static Coroutine To(Transform transform, Vector3 targetPosition, float time, bool isLocal = false)
        {
            return Instance.StartCoroutine(MoveTo(transform, targetPosition, time, isLocal));
        }
        
        public static Coroutine To(RectTransform rectTransform, Vector3 targetPosition, float time)
        {
            return Instance.StartCoroutine(MoveUiTo(rectTransform, targetPosition, time));
        }
        
        private static IEnumerator MoveTo(Transform transform, Vector3 position, float timeToMove, bool isLocal)
        {
            StartAction();
            if(!isLocal)
            {
                var currentPos = transform.position;
                var t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime / timeToMove;
                    transform.position = Vector3.Lerp(currentPos, position, t);
                    yield return null;
                }
            }
            else
            {
                var currentPos = transform.localPosition;
                var t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime / timeToMove;
                    transform.localPosition = Vector3.Lerp(currentPos, position, t);
                    yield return null;
                }
            }
            EndAction();
        }

        private static IEnumerator MoveUiTo(RectTransform rectTransform, Vector3 position, float timeToMove)
        {
            StartAction();
            var currentPos = rectTransform.anchoredPosition;
            var t = 0f;
            while(t < 1)
            {
                t += Time.deltaTime / timeToMove;
                rectTransform.anchoredPosition = Vector3.Lerp(currentPos, position, t);
                yield return null;
            }
            EndAction();
        }
        
        public static void JumpTo(Transform transform, Vector3 targetPosition, float height, float time, bool isLocal = false)
        {
            if(isLocal)
                targetPosition += transform.position;
            Instance.StartCoroutine(IEJumpTo(transform, targetPosition, height, time));
        }
        
        private static IEnumerator IEJumpTo(Transform transform, Vector3 position, float height, float timeToMove)
        {
            StartAction();
            var startX = transform.position.x;
            var startY = transform.position.y;
            var currentPos = transform.position;

            var t = 0f;
            while(t < 1)
            {
                t += Time.deltaTime / timeToMove;
                var targetPos = Vector3.Lerp(currentPos, position, t);
                targetPos.y = startY + height * Mathf.Sin(Mathf.Clamp01(t) * Mathf.PI);
                transform.position = targetPos;
                yield return null;
            }
            EndAction();

        }
        
        
    }
}