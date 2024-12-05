using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryScripts
{
    public class Inventory : MonoBehaviour
    {
        private List<InventoryItem> InventoryItems = new List<InventoryItem>();

        public Action UpdateInventory;
        
        public static Inventory Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
        }
        
        public void Add(Item item, int amount = 1)
        {
            foreach (var i in InventoryItems)
            {
                if(i.TryAdd(item, amount))
                {
                    UpdateInventory?.Invoke();
                    return;
                }
            }

            var newInventoryItem = new InventoryItem(item, amount);
            InventoryItems.Add(newInventoryItem);
            UpdateInventory?.Invoke();
        }

        public InventoryItem[] GetInventory() => InventoryItems.ToArray();
    }
    
    public class InventoryItem
    {
        public Item Item { get; private set; }
        public int Amount { get; private set; }

        public InventoryItem(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }
        
        public bool IsMatchingType(Item itemToCheck)
        {
            return Item.type == itemToCheck.type;
        }

        public bool TryAdd(Item itemToAdd, int amount)
        {
            if (IsMatchingType(itemToAdd))
            {
                Amount += amount;
                return true;
            }

            return false;
        }
    }
}
