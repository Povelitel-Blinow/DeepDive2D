using System.Collections;
using UnityEngine;

namespace CargoShipScripts
{
    [RequireComponent(typeof(Animator))]
    public class CargoShip : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float crossFade;
        [SerializeField] private Cargo cargo;
        
        private const string LandingAnimation = "CargoShipLanding";
        private const string FlyAwayAnimation = "CargoShipFlyAway";
        
        public void Init(float landingTime, float flyAwayTime)
        {
            StartCoroutine(Landing(landingTime, flyAwayTime));
        }

        private IEnumerator Landing(float landingTime, float flyAwayTime)
        {
            PlayAnimationTime(LandingAnimation, landingTime);
            yield return new WaitForSeconds(landingTime);
            cargo.Drop();
            PlayAnimationTime(FlyAwayAnimation, flyAwayTime);
            yield return new WaitForSeconds(flyAwayTime);
            
            Destroy(gameObject);
        }
        
        private void PlayAnimationTime(string animationName, float time)
        {
            animator.Play(animationName);
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            animator.speed = stateInfo.length/time;
        }
        
        private void OnValidate()
        {
            animator ??= GetComponent<Animator>();
        }
    }
}
