using System.Collections;
using UnityEngine;

namespace CargoShipScripts
{
    public class CargoShipHandler : MonoBehaviour
    {
        [SerializeField] private CargoShip ship;
        [SerializeField] private float landingTime;
        [SerializeField] private float flyAwayTime;
        [SerializeField] private float openTime;
        
        public static CargoShipHandler Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
        
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
