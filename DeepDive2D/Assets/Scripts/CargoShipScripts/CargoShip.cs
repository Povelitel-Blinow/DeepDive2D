using System;
using System.Collections;
using Camera;
using PlayerScripts;
using UnityEngine;

namespace CargoShipScripts
{
    [RequireComponent(typeof(Animator))]
    public class CargoShip : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float crossFade;
        [SerializeField] private Cargo cargo;
        
        [Header("Shaking")]
        [SerializeField] private Vector2 shakingPeriod;
        [SerializeField] private Vector2 shakingPower;
        [SerializeField] private float shakingStartDistance = 30;
        [SerializeField] private Transform shakePos;
        
        private const string LandingAnimation = "CargoShipLanding";
        private const string FlyAwayAnimation = "CargoShipFlyAway";

        public Action<Cargo> OnDrop;

        private void Update()
        {
            float distance = (Player.Instance.transform.position - shakePos.position).magnitude;

            float power = distance < shakingStartDistance
                ? Mathf.Lerp(shakingPower.y, shakingPower.x, distance / shakingStartDistance) : 0;
            
            float period = distance < shakingStartDistance
                ? Mathf.Lerp(shakingPeriod.x, shakingPeriod.y, distance / shakingStartDistance) : 1;
            
            CameraShaker.Instance.SetShaking(power, period);
            /*
            if (distance < shakingStartDistance)
                CameraShaker.Instance.SetShaking(
                    shakingPower * Mathf.Clamp(distance / shakingStartDistance, shakingPeriod.x, shakingPeriod.y),
                    Mathf.Clamp(shakingStartDistance / distance, shakingPeriod.x, shakingPeriod.y));
            else
                CameraShaker.Instance.SetShaking(0, 1);*/
        }

        public void Init(float landingTime, float flyAwayTime)
        {
            StartCoroutine(Landing(landingTime, flyAwayTime));
        }

        private IEnumerator Landing(float landingTime, float flyAwayTime)
        {
            PlayAnimationTime(LandingAnimation, landingTime);
            yield return new WaitForSeconds(landingTime);
            cargo.Drop();
            OnDrop?.Invoke(cargo);
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
