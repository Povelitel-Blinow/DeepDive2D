using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerInventoryUI
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image sprite;
        [SerializeField] private TextMeshProUGUI amountText;
        
        public void VoidSlot()
        {
            gameObject.SetActive(false);
            sprite.sprite = null;
            amountText.text = "";
        }
        
        public void Show(InventoryItem item)
        {
            gameObject.SetActive(true);
            sprite.sprite = item.Item.itemSprite;
            amountText.text = item.Amount.ToString();
        }
    }
}
