using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/Level0State", fileName = "Level0State")]
    public class Level0State : LevelState
    {
        protected override void OnInit()
        {
            PlayerUI.Instance.SetDiggingUI(false);
            PlayerUI.Instance.SetMoveUI(true);
            PlayerUI.Instance.SetLevel0UI(true);
        }

        public override void Update()
        {
            
        }

        public override void OnChange()
        {
            PlayerUI.Instance.SetLevel0UI(true);
        }
    }
}
