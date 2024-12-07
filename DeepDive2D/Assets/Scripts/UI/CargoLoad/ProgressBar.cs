using System;
using UnityEngine;

namespace UI.CargoLoad
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Transform bar;
        [SerializeField] private float easeTime;
        
        private float targetRatio;

        private void Start()
        {
            bar.localScale = new Vector3(0, 1, 1);
        }

        private void Update()
        {
            float currentRatio = bar.localScale.x;
            
            if(Mathf.Approximately(targetRatio, currentRatio)) return;

            currentRatio = Mathf.Lerp(currentRatio, targetRatio, Time.deltaTime/easeTime);
            bar.localScale = new Vector3(currentRatio, 1, 1);
        }

        public void SetRatio(float ratio)
        {
            targetRatio = ratio;
        }
    }
}
