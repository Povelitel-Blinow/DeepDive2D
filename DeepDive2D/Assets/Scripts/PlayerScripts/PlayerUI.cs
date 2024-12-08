using InventoryScripts;
using UI;
using UI.BonUI;
using UI.CargoLoad;
using UI.DarUI;
using UI.LazerUI;
using UI.MineUI;
using UI.PlavilnyaUI;
using UI.PlayerInventoryUI;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private GameObject moveUI;
        [SerializeField] private GameObject diggingUI;
        [SerializeField] private InventoryUI inventoryUI;
        [SerializeField] private DarUI darUI;
        [SerializeField] private CargoLoadUI cargoLoadUI;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private BonUI bonUI;
        
        [Header("FloorsUI")]
        [SerializeField] private MineUI mineUI;
        public MineUI MineUI => mineUI;
        [SerializeField] private UnbuiltUI unbuiltUI;
        public UnbuiltUI UnbuiltUI => unbuiltUI;
        [SerializeField] private LazerUI lazerUI;
        public LazerUI LazerUI => lazerUI;
        [SerializeField] private PlavilnyaUI plavilnyaUI;
        public PlavilnyaUI PlavilnyaUI;


        public static PlayerUI Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
            inventoryUI.Init();
            cargoLoadUI.Init();
            soundManager.Init();
            bonUI.Init();
        }
        
        public void SetDiggingUI(bool state)
        {
            diggingUI.SetActive(state);
        }

        public void SetMoveUI(bool state)
        {
            moveUI.SetActive(state);
        }

        public void ShowDarUI(InventoryItem bon, Item stone1, Item stone2) =>
            darUI.Show(bon, stone1, stone2);
    }
}
