using System.Collections;
using UnityEngine;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class SpriteShaker : MonoBehaviour
    {
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float shakeTime;

        public void Shake()
        {
            StopShaking();
            StartCoroutine(Shaking());
        }

        private void StopShaking()
        {
            StopAllCoroutines();
            transform.localScale = Vector2.one;
        }
        
        private IEnumerator Shaking()
        {
            float timer = 0;

            while (timer < shakeTime)
            {
                timer += Time.deltaTime;
                float scale = curve.Evaluate(timer / shakeTime);

                transform.localScale = new Vector3(1, scale, 1);
                yield return new WaitForEndOfFrame();
            }
        }

        public void Press(float time)
        {
            StopAllCoroutines();
            StartCoroutine(Pressing(time));
        }

        private IEnumerator Pressing(float time)
        {
            float timer = 0;

            while (timer < time)
            {
                timer += Time.deltaTime;
                transform.localScale = new Vector3(1, (time-timer)/time, 1);
                yield return new WaitForEndOfFrame();
            }
            
            transform.localScale = Vector3.zero;
        }
    }
}
