using UnityEngine;

namespace PlayerScripts.PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        public void UpdateInput()
        {
            HandleVerticalInput();
        }

        private void HandleVerticalInput()
        {
            int dir = 0;
            if (Input.GetKeyDown(KeyCode.W))
                dir += 1;

            if (Input.GetKeyDown(KeyCode.S))
                dir -= 1;

            Player.Instance.MoveVertical(dir);
        }
    }
}
