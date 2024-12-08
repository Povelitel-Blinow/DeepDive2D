using System.Collections.Generic;
using InventoryScripts;
using UnityEngine;

namespace BuildingScripts
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private Item[] itemsPossibleToMine;
        [SerializeField] private float miningTime;
        [SerializeField] private int capacity;

        [SerializeField] private GameObject mine;
        
        private List<InventoryItem> minedItems;

        private int mined = 0;
        
        private float timer = 0;

        private bool isBuilt = false;
        
        public void Build()
        {
            minedItems = new List<InventoryItem>();
            isBuilt = true;
            Instantiate(mine, transform.position, Quaternion.identity);
        }
        
        private void Update()
        {
            if(isBuilt == false) return;
            
            timer += Time.deltaTime;

            if (timer > miningTime)
            {
                timer = 0;
                MineItem();
            }
        }

        private void MineItem()
        {
            if(mined >= capacity) return;
            
            mined += 1;
            
            var item = itemsPossibleToMine[Random.Range(0, itemsPossibleToMine.Length)];

            foreach (var i in minedItems)
            {
                if (i.TryAdd(item, 1))
                {
                    return;
                }
            }

            InventoryItem inventoryItem = new InventoryItem(item, 1);
            minedItems.Add(inventoryItem);
        }

        public void PickUp()
        {
            foreach (var i in minedItems)
            {
                Inventory.Instance.Add(i.Item, i.Amount);
            }

            mined = 0;
            minedItems = new List<InventoryItem>();
        }

        public InventoryItem[] GetMinedItems() => minedItems.ToArray();
    }
}
