using CargoShipScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.CargoLoad
{
    public class CargoRequestButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            CargoShipHandler.Instance.Call();
        }
    }
}
