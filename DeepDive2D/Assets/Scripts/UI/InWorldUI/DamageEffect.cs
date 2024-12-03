using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.InWorldUI
{
    public class DamageEffect : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float showTime;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private AnimationCurve curve;
        
        public void Init(int damage)
        {
            StartCoroutine(Showing(damage));
        }

        private void Update()
        {
            transform.position += (Vector3)Vector2.up * (Time.deltaTime * moveSpeed);
        }

        private IEnumerator Showing(int damage)
        {
            text.text = damage.ToString();
            float timer = 0;

            while (timer < showTime)
            {
                float alpha = Mathf.Clamp01(curve.Evaluate(timer / showTime));
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            Destroy(gameObject);
        }
    }
}
