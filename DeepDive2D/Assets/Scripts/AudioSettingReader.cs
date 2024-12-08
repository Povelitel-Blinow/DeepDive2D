using System;
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
        if (audioSource == null)
        {
            SettingsUI.OnUpdate -= ChangeVolume;
            return;
        }
        
        audioSource.volume = startVolume * SettingsUI.volume;
    }


    private void OnDestroy()
    {
        SettingsUI.OnUpdate -= ChangeVolume;
    }

    private void OnValidate()
    {
        audioSource ??= GetComponent<AudioSource>();
    }
}
