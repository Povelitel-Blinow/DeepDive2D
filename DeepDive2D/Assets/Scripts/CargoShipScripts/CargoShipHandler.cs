using System.Collections;
using InventoryScripts;
using PlayerScripts;
using UnityEditor;
using UnityEngine;

namespace CargoShipScripts
{
    public class CargoShipHandler : MonoBehaviour
    {
        [SerializeField] private CargoShip ship;
        [SerializeField] private float landingTime;
        [SerializeField] private float flyAwayTime;
        [SerializeField] private float openTime;
        
        [Header("ContainerLoading")]
        [SerializeField] private CargoLoadHandler loader;

        [Header("Cargo")] 
        [SerializeField] private Item bon;
        [SerializeField] private Vector2Int bonAmountRange;
        [SerializeField] private Item[] stones;
        [SerializeField] private Item defaultStone;
        [SerializeField] private int stoneGetChanceOneOutOf;

        [Header("Sound")] 
        [SerializeField] private Alarm alarm;
        
        public static CargoShipHandler Instance { get; private set; }

        public void Init()
        {
            Instance = this;
            loader.Init();
        }

        public bool TryAddItem(Item item) => loader.AddItem(item);
        public float GetCargoRatio() => loader.GetCargoRatio();
        public void VoidCargo() => loader.VoidCargo();
        
        public void Call()
        {
            alarm.Play();
            CargoShip cargoShip = Instantiate(ship, Vector3.zero, Quaternion.identity);
            cargoShip.Init(landingTime, flyAwayTime);
            cargoShip.OnDrop += OpenCargo;
        }

        private void OpenCargo(Cargo cargo)
        {
            StartCoroutine(Openning(cargo));
        }

        private IEnumerator Openning(Cargo cargo)
        {
            yield return new WaitForSeconds(openTime);

            var bons = new InventoryItem(bon, Random.Range(bonAmountRange.x, bonAmountRange.y));
            Inventory.Instance.Add(bon, bons.Amount);
            
            Item stone1 = stones[0];
            Item stone2 = defaultStone;

            Inventory.Instance.Add(stone1);
            
            if (Random.Range(0, stoneGetChanceOneOutOf) == 0)
            { 
                stone2 = stones[0];
                Inventory.Instance.Add(stone2);
            }
            
            PlayerUI.Instance.ShowDarUI(bons, stone1, stone2);
            cargo.Delete();
        }
    }
}
