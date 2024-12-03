using System;
using System.Collections;
using GroundScripts.LevelScripts.Controls.Plasts;
using UnityEngine;

namespace BuildingScripts
{
    [RequireComponent(typeof(LazerUpgrade))]
    public class Lazer : MonoBehaviour
    {
        [Header("Upgrades")] 
        [SerializeField] private LazerUpgrade upgrade;
        
        [Header("Shooting")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Transform muzzle;
        [SerializeField] private LineRenderer lineRenderer;

        [Header("Settings")] 
        [SerializeField] private float lazeringTime;
        
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
                StopAllCoroutines();
                StartCoroutine(Lazering(hit.point));
                
                plast.Damage(upgrade.GetDamage());
            }
        }

        private IEnumerator Lazering(Vector3 hit)
        {
            lineRenderer.SetPosition(0, muzzle.position);
            lineRenderer.SetPosition(1, hit+Vector3.down*0.5f);
            lineRenderer.enabled = true;
            
            float timer = 0;
            while (timer < lazeringTime)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            lineRenderer.enabled = false;
        }

        private void OnValidate()
        {
            upgrade ??= GetComponent<LazerUpgrade>();
        }
    }
}
