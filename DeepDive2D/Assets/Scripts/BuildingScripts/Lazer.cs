using GroundScripts.LevelScripts.Controls.Plasts;
using UnityEngine;

namespace BuildingScripts
{
    public class Lazer : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Transform muzzle;
        public static Lazer Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }

        public void Shoot()
        {
            RaycastHit2D hit = Physics2D.Raycast(muzzle.position, -muzzle.up,
                Mathf.Infinity, layerMask);

            if(hit.collider == null) return;
            
            if (hit.collider.TryGetComponent(out Plast plast))
            {
                plast.DestroyPlast();
            }
        }
    }
}
