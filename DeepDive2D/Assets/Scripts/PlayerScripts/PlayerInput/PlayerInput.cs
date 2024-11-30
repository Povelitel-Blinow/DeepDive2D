using System;
using UnityEngine;

namespace PlayerScripts.PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        public Action<int> OnMove;
        
        public void UpdateInput()
        {
            HandleMoveInput();
        }

        private void HandleMoveInput()
        {
            //The list of levels is inverted
            
            int dir = 0;
            if (Input.GetKeyDown(KeyCode.W))
                dir += 1;

            if (Input.GetKeyDown(KeyCode.S))
                dir -= 1;
            
            if(dir == 0) return;

            OnMove(dir);
        }
        
        public void Move(int dir)
        {
            OnMove(dir);
        }
    }
}
