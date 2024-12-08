using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlavilnyaUI
{
    public class PlavilnyaItem : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI amountText;
        
        public void SetItem(Item item, int amount)
        {
            gameObject.SetActive(true);
            image.sprite = item.itemSprite;
            amountText.text = amount.ToString();
        }

        public void HideItem()
        {
            gameObject.SetActive(false);
        }
    }
}
