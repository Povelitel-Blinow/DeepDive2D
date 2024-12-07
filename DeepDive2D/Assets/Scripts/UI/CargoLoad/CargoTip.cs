using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.CargoLoad
{
    public class CargoTip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float showTime;
        [SerializeField] private AnimationCurve curve;
        
        public void Show()
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            StopAllCoroutines();
            Root.Instance.StopCoroutine(Showing());
            Root.Instance.StartCoroutine(Showing());
        }
        
        private IEnumerator Showing()
        {
            float timer = 0;

            while (timer < showTime)
            {
                float alpha = Mathf.Clamp01(curve.Evaluate(timer / showTime));
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }
    }
}
