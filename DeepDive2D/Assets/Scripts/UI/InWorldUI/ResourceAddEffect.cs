using System.Collections;
using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InWorldUI
{
    public class ResourceAddEffect : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float showTime;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private AnimationCurve curve;
        
        public void Init(Item item, int amount)
        {
            StartCoroutine(Showing(item, amount));
        }

        private void Update()
        {
            transform.position += (Vector3)Vector2.up * (Time.deltaTime * moveSpeed);
        }

        private IEnumerator Showing(Item item, int amount)
        {
            amountText.text = amount.ToString();
            image.sprite = item.itemSprite;
            float timer = 0;

            while (timer < showTime)
            {
                float alpha = Mathf.Clamp01(curve.Evaluate(timer / showTime));
                amountText.color = new Color(amountText.color.r, amountText.color.g, amountText.color.b, alpha);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            Destroy(gameObject);
        }
    }
}
