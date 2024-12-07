using UnityEngine;

namespace CargoShipScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Cargo : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        public void Drop()
        {
            transform.parent = null;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        public void Delete()
        {
            Destroy(gameObject);
        }
        
        private void OnValidate()
        {
            rb ??= GetComponent<Rigidbody2D>();
        }
    }
}
