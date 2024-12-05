using InventoryScripts;
using TMPro;
using UnityEngine;

namespace UI.PlayerInventoryUI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] slots;

        [Header("Info")] 
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI descriptionText;

        private InventorySlot currentHighLightedSlot;
        
        public void Init()
        {
            VoidInfo();
            Inventory.Instance.UpdateInventory += UpdateUI;
            foreach (var slot in slots)
            {
                slot.VoidSlot();
                slot.OnClick += ShowInfo;
            }
        }

        private void VoidInfo()
        {
            nameText.text = "";
            descriptionText.text = "";
        }

        private void UpdateUI()
        {
            ShowInventoryLayout(Inventory.Instance.GetInventory());
        }

        private void ShowInventoryLayout(InventoryItem[] items)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < items.Length)
                {
                    slots[i].Show(items[i]);
                }
                else
                {
                    slots[i].VoidSlot();
                }
            }
        }
        
        private void ShowInfo(InventorySlot slot)
        {
            if (currentHighLightedSlot == slot)
            {
                currentHighLightedSlot.DeHighLightSlot();
                currentHighLightedSlot = null;
                VoidInfo();
            }else
            {
                if(currentHighLightedSlot != null)
                    currentHighLightedSlot.DeHighLightSlot();
                
                currentHighLightedSlot = slot;
                currentHighLightedSlot.HighLightSlot();
                nameText.text = currentHighLightedSlot.Item.Item.name;
                descriptionText.text = currentHighLightedSlot.Item.Item.type.ToString();
            }
        }
    }
}
