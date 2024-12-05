using System;
using InventoryScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.PlayerInventoryUI
{
    public class InventorySlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image sprite;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private GameObject outline;

        private InventoryItem currentItem;
        
        public Action<InventorySlot> OnClick;
        public InventoryItem Item => currentItem;
        
        public void VoidSlot()
        {
            gameObject.SetActive(false);
            sprite.sprite = null;
            amountText.text = "";
            currentItem = null;
        }
        
        public void Show(InventoryItem item)
        {
            currentItem = item;
            sprite.sprite = item.Item.itemSprite;
            amountText.text = item.Amount.ToString();
            gameObject.SetActive(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(currentItem == null) return;
            
            OnClick?.Invoke(this);
        }

        public void HighLightSlot()
        {
            outline.SetActive(true);
        }

        public void DeHighLightSlot()
        {
            outline.SetActive(false);
        }
    }
}
