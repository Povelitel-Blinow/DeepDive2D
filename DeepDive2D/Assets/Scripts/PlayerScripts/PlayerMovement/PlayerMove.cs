using GroundScripts.LevelScripts;
using UnityEngine;

namespace PlayerScripts.PlayerMovement
{
    public class PlayerMove : MonoBehaviour
    {
        private Level targetLevel;
        
        public void MoveTo(Level level)
        { 
            targetLevel = level;

            transform.position = targetLevel.transform.position;
        }
    }
}
