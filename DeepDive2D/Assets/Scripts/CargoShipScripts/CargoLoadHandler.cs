using System.Collections.Generic;
using InventoryScripts;
using UnityEngine;

namespace CargoShipScripts
{
    public class CargoLoadHandler : MonoBehaviour
    {
        [SerializeField] private int[] neededMasses;

        private CargoContainer currentContainer;
        private int currentCargoNumber = 0;

        public void Init()
        {
            NewContainer();
        }

        public void NewContainer()
        {
            currentCargoNumber = Mathf.Clamp(currentCargoNumber, 0, neededMasses.Length - 1);
            currentContainer = new CargoContainer(neededMasses[currentCargoNumber]);
            currentCargoNumber += 1;
        }
        
        public bool AddItem(Item item)
        {
            return currentContainer.AddItem(item);
        }

        public float GetCargoRatio() => currentContainer.GetMassRatio();

        public void VoidCargo()
        {
            NewContainer();
        }
        
        private class CargoContainer
        {
            private List<Item> items;
            private int currentMass;
            
            private readonly int neededMass;
            
            public CargoContainer(int mass)
            {
                items = new List<Item>();
                neededMass = mass;
            }
            
            public bool AddItem(Item item)
            {
                if (currentMass > neededMass)
                    return false;
                
                currentMass += item.mass;
                items.Add(item);
                return true;
            }
            
            public float GetMassRatio()
            {
                return Mathf.Clamp01((float)currentMass / neededMass);
            }
        }
    }
}
