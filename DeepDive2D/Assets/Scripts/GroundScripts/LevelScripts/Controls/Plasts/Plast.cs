using System;
using UI.InWorldUI;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class Plast : MonoBehaviour
    {
        [SerializeField] private float destroyDelay = 0.2f;
        
        [Header("Effects")] 
        [SerializeField] private DamageEffect damageEffect;
        [SerializeField] private float damageEffectSpread;
        [SerializeField] private Transform effectSpawnPos;
        
        [Header("Health Bar")]
        [SerializeField] private PlastHealthBar healthBar;
        
        [Header("SpiteShaker")]
        [SerializeField] private SpriteShaker spriteShaker;
        
        private int currentHp;
        private int maxHp;
        
        public Action<Plast> Deregister;

        public void Init(int hp)
        {
            maxHp = hp;
            currentHp = hp;
        }
        
        public void Damage(int damage)
        {
            if(currentHp <= 0) return;
            
            SpawnEffect(damage);
            currentHp -= damage;
            healthBar.SetRatio((float)currentHp/maxHp);
            spriteShaker.Shake();
            if (currentHp <= 0)
            {
                DestroyPlast();
                return;
            }
        }

        private void SpawnEffect(int damage)
        {
            Vector2 pos = effectSpawnPos.position + 
                          Vector3.right * Random.Range(-damageEffectSpread, damageEffectSpread);

            Instantiate(damageEffect, pos, quaternion.identity).Init(damage);
        }
        
        private void DestroyPlast()
        {
            Destroy(gameObject, destroyDelay);
        }

        private void OnDestroy()
        {
            Deregister?.Invoke(this);
        }
    }
}
