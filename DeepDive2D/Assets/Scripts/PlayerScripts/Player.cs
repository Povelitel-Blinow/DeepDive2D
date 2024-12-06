using GroundScripts;
using GroundScripts.LevelScripts;
using PlayerScripts.PlayerMovement;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerInput.PlayerInput))]
    [RequireComponent(typeof(PlayerMove))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput.PlayerInput input;
        [SerializeField] private PlayerMove move;
        
        public static Player Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
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

        private void OnValidate()
        {
            input ??= GetComponent<PlayerInput.PlayerInput>();
            move ??= GetComponent<PlayerMove>();
        }
    }
}
