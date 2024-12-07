using System.Collections;
using InventoryScripts;
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
            
            //PlayerUI.Instance.ShowDarUI();
            cargo.Delete();
        }
    }
}
