using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/UnDugged", fileName = "UnDuggedLevel")]
    public class UnDugged : LevelState
    {
        [Header("States")]
        [SerializeField] private LevelState nextLevelState;

        protected override void OnInit()
        {
            controls.plasts.Init(controls.settings.BaseHealth, controls.settings.HealthIncreaseRatio);
        }

        public override void Update()
        {
            if (controls.plasts.GetLevelIsDugged())
            {
                PlayerUI.Instance.SetDiggingUI(false);
                ChangeState(nextLevelState);
                return;
            }
        }

        public override void OnVisit()
        {
            PlayerUI.Instance.SetDiggingUI(true);
        }

        public override void OnExit()
        {
            PlayerUI.Instance.SetDiggingUI(false);
        }
    }
}
