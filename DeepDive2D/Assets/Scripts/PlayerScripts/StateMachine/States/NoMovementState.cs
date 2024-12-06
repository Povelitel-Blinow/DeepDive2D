namespace PlayerScripts.StateMachine.States
{
    public class NoMovementState : PlayerState
    {
        public override void Init()
        {
            PlayerUI.Instance.SetDiggingUI(false);
            PlayerUI.Instance.SetMoveUI(false);
        }

        public override void Update()
        {
            
        }

        public override void MoveVertical(int dir)
        {
            //No Movement
        }
    }
}
