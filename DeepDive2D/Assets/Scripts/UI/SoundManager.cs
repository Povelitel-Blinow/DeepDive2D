using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        [Header("Sounds")] 
        [SerializeField] private AudioClip buttonClick;
        [SerializeField] private AudioClip openCase;
        [SerializeField] private AudioClip plastDestroy;
        [SerializeField] private AudioClip lazerSound;

        public static SoundManager Instance { get; private set; }
        
        public void Init()
        {
            Instance = this;
        }
        
        public void PlayButtonClick()
        {
            source.PlayOneShot(buttonClick);    
        }

        public void PlayCaseOpen(float volume = 1)
        {
            source.PlayOneShot(openCase, volume);
        }

        public void PlayPlastDestroy(float volume = 1)
        {
            source.PlayOneShot(plastDestroy, volume);
        }

        public void PlaySoundLazer(float volume = 1)
        {
            source.PlayOneShot(lazerSound, volume);
        }
        
        private void OnValidate()
        {
            source ??= GetComponent<AudioSource>();
        }
    }
}
