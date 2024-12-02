using UnityEngine;

namespace PlayerScripts.StateMachine.States
{
    [CreateAssetMenu(menuName = "PlayerStates/Common", fileName = "CommonState")]
    public class CommonState : PlayerState
    {
        public override void Init()
        {
            PlayerUI.Instance.SetDiggingUI(false);
            PlayerUI.Instance.SetMoveUI(true);
        }

        public override void Update()
        {
            
        }
    }
}
