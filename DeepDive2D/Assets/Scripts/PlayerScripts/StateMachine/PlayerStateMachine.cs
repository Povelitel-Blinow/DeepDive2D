using PlayerScripts.StateMachine.States;
using UnityEngine;

namespace PlayerScripts.StateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerState currentState;
        
        public void UpdateStateMachine()
        {
            if(currentState == null) return;
            
            currentState.Update();
        }
        
        public void ChangeState(PlayerState state)
        {
            if(currentState != null)
                Destroy(currentState);

            currentState = Instantiate(state);
            currentState.Init();
        }

        public void MoveVertical(int direction)
        {
            currentState.MoveVertical(direction);
        }
    }
}
