using System;
using InventoryScripts;
using UI.CargoLoad;
using UnityEngine;

namespace UI.PlavilnyaUI
{
    public class PlavilnyaUI : MonoBehaviour
    {
        [SerializeField] private PlavilnyaItem resouce;
        [SerializeField] private PlavilnyaItem resultMaterial;

        [SerializeField] private ProgressBar progressBar;

        public Action OnPickUp;
        
        public void SetProgressBar(float ratio)
        {
            progressBar.SetRatio(ratio);
        }

        public void SetResourceAmount(Item item, int amount)
        {
            resouce.SetItem(item, amount);
        }
        
        public void SetResultMaterialAmount(Item item, int amount)
        {
            resultMaterial.SetItem(item, amount);
        }

        public void PickUp()
        {
            OnPickUp?.Invoke();
        }
    }
}
