using System.Collections;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class MenuError : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float showTime;
        [SerializeField] private AnimationCurve curve;
        
        public void Show()
        {
            StopAllCoroutines();
            StartCoroutine(Showing());
        }

        private IEnumerator Showing()
        {
            float timer = 0;
            while (timer < showTime)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Clamp01(curve.Evaluate(timer / showTime));
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
