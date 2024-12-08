using InventoryScripts;
using TMPro;
using UnityEngine;

namespace UI.PlayerInventoryUI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] slots;
        [SerializeField] private int[] movePositions;
        [SerializeField] private RectTransform moveable;

        [Header("Info")] 
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private GameObject emptyText;

        private InventorySlot currentHighLightedSlot;
        
        private int currentPosIndex;
        
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
            nameText.text = "-";
            descriptionText.text = "Нажмите на ресурс, чтобы посмотреть описание";
        }

        private void UpdateUI()
        {
            ShowInventoryLayout(Inventory.Instance.GetInventory());
        }

        private void ShowInventoryLayout(InventoryItem[] items)
        {
            emptyText.SetActive(items.Length == 0);
            
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

        public void MoveVertical(int dir)
        {
            currentPosIndex = Mathf.Clamp(currentPosIndex + dir, 0, movePositions.Length-1);

            moveable.transform.localPosition = new Vector3(0, movePositions[currentPosIndex], 0);
        }
    }
}
