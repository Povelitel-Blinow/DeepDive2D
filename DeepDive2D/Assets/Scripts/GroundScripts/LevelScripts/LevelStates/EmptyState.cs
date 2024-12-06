using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/Empty", fileName = "EmptyLevel")]
    public class EmptyState : LevelState
    {
        public override void Update()
        {
            
        }

        public override void OnVisit()
        {
            PlayerUI.Instance.SetMoveUI(true);
        }

        public override void OnExit()
        {
            
        }
    }
}
