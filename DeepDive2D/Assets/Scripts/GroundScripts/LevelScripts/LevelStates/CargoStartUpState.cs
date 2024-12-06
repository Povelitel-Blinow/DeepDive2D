using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/LevelCargoStartUp", fileName = "CargoStartUp")]
    public class CargoStartUpState : LevelState
    {
        protected override void OnInit()
        {
            PlayerUI.Instance.SetCargoStartUpUI(true);
            PlayerUI.Instance.SetDiggingUI(false);
            PlayerUI.Instance.SetMoveUI(false);
        }

        public override void Update()
        {
            
        }

        public override void OnChange()
        {
            PlayerUI.Instance.SetCargoStartUpUI(false);
        }
    }
}
