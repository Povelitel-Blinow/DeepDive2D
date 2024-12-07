using InventoryScripts;
using UI.DarUI;
using UI.PlayerInventoryUI;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private GameObject moveUI;
        [SerializeField] private GameObject diggingUI;
        [SerializeField] private InventoryUI inventoryUI;
        [SerializeField] private GameObject level0UI;
        [SerializeField] private DarUI darUI;

        public static PlayerUI Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
            inventoryUI.Init();
        }
        
        public void SetDiggingUI(bool state)
        {
            diggingUI.SetActive(state);
        }

        public void SetMoveUI(bool state)
        {
            moveUI.SetActive(state);
        }

        public void SetLevel0UI(bool state)
        {
            level0UI.SetActive(state);
        }

        public void ShowDarUI(InventoryItem bon, InventoryItem stone1, InventoryItem stone2) =>
            darUI.Show(bon, stone1, stone2);
    }
}
