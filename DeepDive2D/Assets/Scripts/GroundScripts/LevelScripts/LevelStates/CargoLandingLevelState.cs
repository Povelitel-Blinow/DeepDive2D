using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/LevelCargoLanding", fileName = "CargoLanding")]
    public class CargoLandingLevelState : LevelState
    {
        protected override void OnInit()
        {
            PlayerUI.Instance.SetCargoLandingUI(true);
            PlayerUI.Instance.SetDiggingUI(false);
            PlayerUI.Instance.SetMoveUI(false);
        }

        public override void Update()
        {
            
        }

        public override void OnChange()
        {
            PlayerUI.Instance.SetCargoLandingUI(false);
        }
    }
}
