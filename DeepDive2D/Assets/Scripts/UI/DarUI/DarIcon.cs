using System.Collections;
using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DarUI
{
    public class DarIcon : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image image;

        [SerializeField] private float showTime;

        public void Show(InventoryItem item)
        {
            StartCoroutine(Showing(item));
        }

        private IEnumerator Showing(InventoryItem item)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            
            float timer = 0;

            image.sprite = item.Item.itemSprite;
            text.text = item.Amount.ToString();
            
            while (timer < showTime)
            {
                float alpha = Mathf.Clamp01(timer / showTime);
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }
        
        public void Hide(){
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            image.sprite = null;
            text.text = "";
        }
    }
}
