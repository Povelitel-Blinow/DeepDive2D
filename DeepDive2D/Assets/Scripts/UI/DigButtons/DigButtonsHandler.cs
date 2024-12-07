using BuildingScripts;
using TMPro;
using UnityEngine;

namespace UI.DigButtons
{
    public class DigButtonsHandler : MonoBehaviour
    {
        [SerializeField] private float lazerSoundVolume = 0.5f;
        [SerializeField] private float showTime;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private AnimationCurve curve;
        
        private float fadeTime;
        private float timer;
        
        private void Update()
        {
            float alpha = Mathf.Clamp01(curve.Evaluate(timer / showTime));
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            
            timer += Time.deltaTime;
        }

        public void ShootLazer()
        {
            SoundManager.Instance.PlaySoundLazer(lazerSoundVolume);
            timer = 0;
            Lazer.Instance.Shoot();
        }
    }
}
