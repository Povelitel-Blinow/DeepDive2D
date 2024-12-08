using UnityEngine;

namespace UI.InWorldUI
{
    public class PlastHealthBar : MonoBehaviour
    {
        [SerializeField] private Transform hpLine;
        [SerializeField] private float easeTime;

        private float ratio;
        
        private void Update()
        {
            float currentRatio = hpLine.localScale.x;
            
            if(Mathf.Approximately(ratio, currentRatio)) return;

            currentRatio = Mathf.Lerp(currentRatio, ratio, Time.deltaTime/easeTime);
            hpLine.localScale = new Vector3(currentRatio, 1, 1);
        }

        public void SetRatio(float damageRatio)
        {
            ratio = Mathf.Clamp01(damageRatio);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
