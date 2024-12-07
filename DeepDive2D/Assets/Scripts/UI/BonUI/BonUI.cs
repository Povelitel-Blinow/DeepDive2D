using InventoryScripts;
using TMPro;
using UnityEngine;

namespace UI.BonUI
{
    public class BonUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Init()
        {
            Inventory.Instance.UpdateInventory += UpdateBons;
        }

        private void UpdateBons()
        {
            text.text = Inventory.Instance.GetBonAmount().ToString();
        }
    }
}
