using UnityEngine;

namespace CargoShipScripts
{
    public class CargoShipHandler : MonoBehaviour
    {
        [SerializeField] private CargoShip ship;
        [SerializeField] private float landingTime;
        [SerializeField] private float flyAwayTime;
        
        public static CargoShipHandler Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
        
        public void Call()
        {
            Instantiate(ship, Vector3.zero, Quaternion.identity).Init(landingTime, flyAwayTime);
        }
    }
}
