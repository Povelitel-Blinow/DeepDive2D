using InventoryScripts;
using UnityEngine;

namespace UI.DarUI
{
    public class DarUI : MonoBehaviour
    {
        [SerializeField] private DarIcon icon1;
        [SerializeField] private DarIcon icon2;
        [SerializeField] private DarIcon icon3;

        public void Show(InventoryItem bon, InventoryItem stone1, InventoryItem stone2)
        {
            Debug.Log(1111);
            gameObject.SetActive(true);
            
            icon1.Show(bon);
            
            if(stone1 != null)
                icon2.Show(stone1);
            else
                icon2.Hide();
            
            if(stone2 != null)
                icon3.Show(stone2);
            else
                icon3.Hide();
        }
    }
}
