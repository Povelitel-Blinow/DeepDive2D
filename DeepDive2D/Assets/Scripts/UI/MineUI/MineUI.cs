using System;
using InventoryScripts;
using UnityEngine;

namespace UI.MineUI
{
    public class MineUI : MonoBehaviour
    {
        [SerializeField] private MinedItem item1;
        [SerializeField] private MinedItem item2;

        public Action OnPickUp;

        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
        
        public void SetMinedItems(InventoryItem[] items)
        {
            if(items.Length >= 1)
                item1.SetItem(items[0]);
            else
                item1.HideItem();
            
            if(items.Length >= 2)
                item2.SetItem(items[1]);
            else
                item2.HideItem();
        }

        public void PickUp()
        {
            OnPickUp?.Invoke();
        }
    }
}
