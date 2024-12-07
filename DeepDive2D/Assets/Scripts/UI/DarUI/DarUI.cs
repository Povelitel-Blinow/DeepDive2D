using InventoryScripts;
using UnityEngine;

namespace UI.DarUI
{
    public class DarUI : MonoBehaviour
    {
        [SerializeField] private DarIcon icon1;
        [SerializeField] private DarIcon icon2;
        [SerializeField] private DarIcon icon3;

        public void Show(InventoryItem bon, Item stone1, Item stone2)
        {
            gameObject.SetActive(true);
            
            icon1.Show(bon);
            
            if(stone1.type == MaterialType.Collectable)
                icon2.Show(stone1);
            else
                icon2.Hide();
            
            if(stone2.type == MaterialType.Collectable)
                icon3.Show(stone2);
            else
                icon3.Hide();
        }
    }
}
