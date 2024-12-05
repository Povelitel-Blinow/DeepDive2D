using InventoryScripts;
using UnityEngine;

namespace UI.PlayerInventoryUI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] slots;
        
        public void Init()
        {
            Inventory.Instance.UpdateInventory += UpdateUI;
            foreach (var slot in slots)
            {
                slot.VoidSlot();
            }
        }

        private void UpdateUI()
        {
            ShowInventoryLayout(Inventory.Instance.GetInventory());
        }
        
        public void Show(bool state)
        {
            if (state)
            {
                ShowInventoryLayout(Inventory.Instance.GetInventory());    
            }
            
            gameObject.SetActive(state);
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
    }
}
