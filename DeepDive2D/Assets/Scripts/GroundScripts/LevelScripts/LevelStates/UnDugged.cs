using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/UnDugged", fileName = "UnDuggedLevel")]
    public class UnDugged : LevelState
    {
        [Header("States")]
        [SerializeField] private EmptyState emptyState;

        protected override void OnInit()
        {
            controls.plasts.Init(controls.settings.BaseHealth, controls.settings.HealthIncreaseRatio);
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
