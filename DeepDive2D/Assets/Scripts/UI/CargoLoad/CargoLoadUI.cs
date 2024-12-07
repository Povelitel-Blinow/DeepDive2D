using System.Collections.Generic;
using CargoShipScripts;
using InventoryScripts;
using TMPro;
using UI.PlayerInventoryUI;
using UnityEngine;

namespace UI.CargoLoad
{
    public class CargoLoadUI : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] slots;
        [SerializeField] private int[] movePositions;
        [SerializeField] private RectTransform moveable;

        [Header("Progress Bars")]
        [SerializeField] private ProgressBar buttonBar;
        [SerializeField] private ProgressBar bar;

        [Header("Info")] 
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private GameObject emptyText;

        [SerializeField] private CargoTip tip;

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
            List<InventoryItem> checkedItems = new List<InventoryItem>();
            
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Item.type == MaterialType.Meterial ||
                    items[i].Item.type == MaterialType.Resource) checkedItems.Add(items[i]);
            }
            
            emptyText.SetActive(checkedItems.Count == 0);
            
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < checkedItems.Count)
                {
                    slots[i].Show(checkedItems[i]);
                }
                else
                {
                    slots[i].VoidSlot();
                }
            }

            if (currentHighLightedSlot == null || currentHighLightedSlot.Item == null)
            {
                VoidInfo();
            }
            else
            {
                nameText.text = currentHighLightedSlot.Item.Item.name;
                descriptionText.text = currentHighLightedSlot.Item.Item.type.ToString();
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

        public void AddCurrentMaterial()
        {
            if(currentHighLightedSlot == null) return;
            if(currentHighLightedSlot.Item == null) return;

            if (CargoShipHandler.Instance.TryAddItem(currentHighLightedSlot.Item.Item))
            {
                Inventory.Instance.Remove(currentHighLightedSlot.Item.Item);
                float ratio = CargoShipHandler.Instance.GetCargoRatio();
                bar.SetRatio(ratio);
                buttonBar.SetRatio(ratio);
            }
        }

        public void TrySend()
        {
            if (CargoShipHandler.Instance.GetCargoRatio() >= 1)
            {
                CargoShipHandler.Instance.Call();
                CargoShipHandler.Instance.VoidCargo();
                bar.SetRatio(0);
                buttonBar.SetRatio(0);
                tip.Show();
            }
        }
    }
}
