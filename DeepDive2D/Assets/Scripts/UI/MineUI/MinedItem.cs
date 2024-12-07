using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MineUI
{
    public class MinedItem : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI amount;
        
        public void SetItem(InventoryItem item)
        {
            gameObject.SetActive(true);
            image.sprite = item.Item.itemSprite;
            amount.text = item.Amount.ToString();
        }

        public void HideItem()
        {
            gameObject.SetActive(false);
        }
    }
}
