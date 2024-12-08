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

        public void Remove(Item item, int amount = 1)
        {
            foreach (var i in InventoryItems)
            {
                if(i.Item.name == item.name)
                {
                    i.Amount -= amount;

                    if (i.Amount <= 0)
                        InventoryItems.Remove(i);
                    
                    UpdateInventory?.Invoke();
                    return;
                }
            }
        }

        public int GetBonAmount()
        {
            foreach (var i in InventoryItems)
            {
                if (i.Item.type == MaterialType.Bon)
                    return i.Amount;
            }

            return 0;
        }

        public void RemoveBon(int amount)
        {
            foreach (var i in InventoryItems)
            {
                if (i.Item.type == MaterialType.Bon)
                {
                    i.Amount -= amount;

                    if (i.Amount <= 0)
                        InventoryItems.Remove(i);
                    
                    UpdateInventory?.Invoke();
                    return;
                }
            }
        }

        public bool HasItemIn(Item item)
        {
            foreach (var i in InventoryItems)
            {
                if (i.IsMatchingNames(item))
                {
                    return true;
                }
            }

            return false;
        }
        
        public InventoryItem[] GetInventory() => InventoryItems.ToArray();
    }
    
    public class InventoryItem
    {
        public Item Item { get; private set; }
        public int Amount;

        public InventoryItem(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }
        
        public bool IsMatchingNames(Item itemToCheck)
        {
            return Item.name == itemToCheck.name;
        }

        public bool TryAdd(Item itemToAdd, int amount)
        {
            if (IsMatchingNames(itemToAdd))
            {
                Amount += amount;
                return true;
            }

            return false;
        }
    }
}
