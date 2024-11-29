using GroundScripts;
using GroundScripts.LevelScripts;
using PlayerScripts.PlayerMovement;
using PlayerScripts.StateMachine;
using PlayerScripts.StateMachine.States;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerInput.PlayerInput))]
    [RequireComponent(typeof(PlayerStateMachine))]
    [RequireComponent(typeof(PlayerMove))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput.PlayerInput input;
        [SerializeField] private PlayerStateMachine stateMachine;
        [SerializeField] private PlayerMove move;
        
        public static Player Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
            input.OnMove += MoveVertical;
        }

        public void UpdatePlayer()
        {
            input.UpdateInput();
        }

        public void MoveVertical(int dir)
        {
            Ground.Instance.MoveVertical(dir);
        }

        public void MoveTo(Level targetLevel)
        {
            move.MoveTo(targetLevel);
        }
        
        public void ChangeState(PlayerState state)
        {
            stateMachine.ChangeState(state);
        }

        private void OnValidate()
        {
            input ??= GetComponent<PlayerInput.PlayerInput>();
            stateMachine ??= GetComponent<PlayerStateMachine>();
            move ??= GetComponent<PlayerMove>();
        }
    }
}
