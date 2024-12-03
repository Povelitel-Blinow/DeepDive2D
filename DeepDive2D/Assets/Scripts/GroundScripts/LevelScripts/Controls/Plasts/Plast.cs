using System;
using UI.InWorldUI;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class Plast : MonoBehaviour
    {
        [SerializeField] private int hp;

        [Header("Effects")] 
        [SerializeField] private DamageEffect damageEffect;
        [SerializeField] private float damageEffectSpread;
        [SerializeField] private Transform effectSpawnPos;
        
        public Action<Plast> Deregister;

        public void Init(int hp)
        {
            this.hp = hp;
        }
        
        public void Damage(int damage)
        {
            Debug.Log(damage);
            
            SpawnEffect(damage);
            hp -= damage;
            if (hp <= 0)
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
            Deregister?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
