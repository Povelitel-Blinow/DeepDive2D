using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/Level0State", fileName = "Level0State")]
    public class Level0State : LevelState
    {
        protected override void OnInit()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void OnChange()
        {
            
        }

        public override void OnVisit()
        {
            PlayerUI.Instance.SetMoveUI(true);
            PlayerUI.Instance.SetLevel0UI(true);
        }

        public override void OnExit()
        {
            PlayerUI.Instance.SetLevel0UI(false);
        }
    }
}
