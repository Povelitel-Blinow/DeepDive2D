using System;
using UnityEngine;

namespace Camera
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private Transform shaker;
        [SerializeField] private AnimationCurve curve;

        [SerializeField] private float power = 0;
        [SerializeField] private float period = 1;
        private float timer = 0;
        
        public static CameraShaker Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > period)
            {
                timer = 0;
            }
            Shake();
        }

        private void Shake()
        {
            shaker.transform.localPosition = new Vector3(shaker.localPosition.x,
                curve.Evaluate(timer/period)*power,
                shaker.localPosition.z);
        }

        public void SetShaking(float power, float period)
        {
            this.power = power;
            this.period = period;
        }
    }
}
