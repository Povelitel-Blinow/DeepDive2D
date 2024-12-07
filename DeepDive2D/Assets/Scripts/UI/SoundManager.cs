using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        [Header("Sounds")] 
        [SerializeField] private AudioClip buttonClick;

        public static SoundManager Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
        }
        
        public void PlayButtonClick()
        {
            source.PlayOneShot(buttonClick);    
        }
        
        private void OnValidate()
        {
            source ??= GetComponent<AudioSource>();
        }
    }
}
