using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/UnDugged", fileName = "UnDuggedLevel")]
    public class UnDugged : LevelState
    {
        [SerializeField] private EmptyState emptyState;

        protected override void OnInit()
        {
            controls.plasts.Init();
        }

        public override void Update()
        {
            if (controls.plasts.GetLevelIsDugged())
            {
                ChangeState(emptyState);
                return;
            }
        }
    }
}
