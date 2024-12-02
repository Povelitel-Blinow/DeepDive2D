using UnityEngine;

namespace PlayerScripts.StateMachine.States
{
    [CreateAssetMenu(menuName = "PlayerStates/DiggingState", fileName = "DiggingState")]
    public class DiggingState : PlayerState
    {
        public override void Init()
        {
            PlayerUI.Instance.SetMoveUI(true);
            PlayerUI.Instance.SetDiggingUI(true);
        }

        public override void Update()
        {
            
        }
    }
}
