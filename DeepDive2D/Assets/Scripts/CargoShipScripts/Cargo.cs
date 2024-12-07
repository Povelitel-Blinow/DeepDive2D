using System;
using UI;
using UnityEngine;

namespace CargoShipScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    public class Cargo : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private AudioClip collideSound;
        [SerializeField] private AudioSource source;
        [SerializeField] private float openSoundVolume = 0.5f;

        public void Drop()
        {
            transform.parent = null;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        public void Delete()
        {
            SoundManager.Instance.PlayCaseOpen(openSoundVolume);
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            source.PlayOneShot(collideSound);
        }

        private void OnValidate()
        {
            rb ??= GetComponent<Rigidbody2D>();
            source ??= GetComponent<AudioSource>();
        }
    }
}
