using System.Collections;
using GroundScripts.LevelScripts;
using UnityEngine;

namespace PlayerScripts.PlayerMovement
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float moveTime;
        
        private Level targetLevel;
        
        public void MoveTo(Level level)
        { 
            targetLevel = level;
            
            StopAllCoroutines();
            StartCoroutine(Moving());
        }

        private IEnumerator Moving()
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = targetLevel.GetCameraTransform().position;
            
            float timer = 0;

            while (timer < moveTime)
            {
                timer += Time.deltaTime;    
                
                float ratio = timer / moveTime;
                
                transform.position = Vector3.Lerp(startPosition, targetPosition, ratio);
                
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
