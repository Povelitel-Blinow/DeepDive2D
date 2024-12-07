using System;
using UnityEngine;

namespace CargoShipScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    public class Cargo : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private AudioClip sound;
        [SerializeField] private AudioSource source;

        public void Drop()
        {
            transform.parent = null;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        public void Delete()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            source.PlayOneShot(sound);
        }

        private void OnValidate()
        {
            rb ??= GetComponent<Rigidbody2D>();
            source ??= GetComponent<AudioSource>();
        }
    }
}
