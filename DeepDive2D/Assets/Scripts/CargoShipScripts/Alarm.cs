using UI;
using UnityEngine;

namespace CargoShipScripts
{
    public class Alarm : MonoBehaviour
    {
        [SerializeField] private AudioClip siren;
        [SerializeField] private AudioSource source;

        public void Play()
        {
            source.PlayOneShot(siren, SettingsUI.volume);
        }
    }
}
