using BuildingScripts;
using UnityEngine;

namespace UI.DigButtons
{
    public class DigButtonsHandler : MonoBehaviour
    {
        public void ShootLazer()
        {
            Lazer.Instance.Shoot();
        }
    }
}
