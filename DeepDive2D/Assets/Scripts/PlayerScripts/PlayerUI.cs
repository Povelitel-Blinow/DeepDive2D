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
    }
}
