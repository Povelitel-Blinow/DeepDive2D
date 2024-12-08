using UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSettingReader : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private float startVolume;
    
    private void Awake()
    {
        startVolume = audioSource.volume;
        ChangeVolume();
        SettingsUI.OnUpdate += ChangeVolume;
    }

    private void ChangeVolume()
    {
        audioSource.volume = startVolume * SettingsUI.volume;
    }
    
    private void OnValidate()
    {
        audioSource ??= GetComponent<AudioSource>();
    }
}
