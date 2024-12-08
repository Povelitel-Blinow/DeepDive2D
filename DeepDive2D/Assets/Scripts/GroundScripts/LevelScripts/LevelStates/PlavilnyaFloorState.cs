using BuildingScripts;
using PlayerScripts;
using UI.PlavilnyaUI;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/PlavilnyaFloorState", fileName = "PlavilnyaFloorState")]
    public class PlavilnyaFloorState : BuildingLevelState
    {
        private Plavilnya plavilnya;
        protected override void OnInit()
        {
            plavilnya = GetComponentInLevel<Plavilnya>();
        }

        public override void Update()
        {
            if(isActive == false) return;
            
            PlayerUI.Instance.PlavilnyaUI.SetProgressBar(plavilnya.GetCookRatio());
        }

        protected override void OnVisit()
        {
            PlayerUI.Instance.PlavilnyaUI.OnPickUp += PickUp;
            PlayerUI.Instance.PlavilnyaUI.SetProgressBar(plavilnya.GetCookRatio());
            
            //PlayerUI.Instance.PlavilnyaUI.SetResourceAmount();
        }

        private void PickUp()
        {
            plavilnya.PickUp();
        }

        protected override void OnExit()
        {
            PlayerUI.Instance.PlavilnyaUI.OnPickUp -= PickUp;
        }
    }
}
