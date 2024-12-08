using System;
using InventoryScripts;
using UnityEngine;

namespace BuildingScripts
{
    public class Plavilnya : MonoBehaviour
    {
        [SerializeField] private Recept[] recepts;
        
        private int currentReceptIndex = 0;
        private float timer = 0;

        private int cooked;
        
        private void Update()
        {
            if (currentReceptIndex == 0) return;

            timer += Time.deltaTime;
            if (timer >= recepts[currentReceptIndex - 1].cookTime)
            {
                timer = 0;
                cooked += 1;
            }
        }

        public float GetCookRatio()
        {
            if (currentReceptIndex == 0) return 0;
            
            return timer / recepts[currentReceptIndex - 1].cookTime;
        }

        public void SetRecept(int dir)
        {
            PickUp();
            
            currentReceptIndex = Mathf.Clamp(currentReceptIndex + dir, 0, recepts.Length - 1);
        }

        public void PickUp()
        {
            if (cooked > 0)
            {
                Inventory.Instance.Add(recepts[currentReceptIndex-1].result, cooked);
                cooked = 0;
            }
        }
        
        public bool IsCooking() => currentReceptIndex != 0;

        public Recept GetCurrentRecept() => recepts[currentReceptIndex-1];
    }
    
    [System.Serializable]
    public class Recept
    {
        public Item resource;
        public Item result;
        public float cookTime;
    }
}
