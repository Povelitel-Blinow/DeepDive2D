using System;
using InventoryScripts;
using UI;
using UI.InWorldUI;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class Plast : MonoBehaviour
    {
        [SerializeField] private float destroyDelay = 0.2f;
        [SerializeField] private float destroyVolume = 0.2f;
        [SerializeField] private Collider2D collider2D;
        [SerializeField] private Vector2Int OnDamageResourceAdditionBorders;
        [SerializeField] private Vector2Int OnDestroyResourceAdditionBorders;
        
        [Header("Damage Effect")] 
        [SerializeField] private DamageEffect damageEffect;
        [SerializeField] private float damageEffectSpread;
        [SerializeField] private Transform effectSpawnPos;
        
        [Header("Health Bar")]
        [SerializeField] private PlastHealthBar healthBar;
        
        [Header("SpiteShaker")]
        [SerializeField] private SpriteShaker spriteShaker;

        [Header("Resources")] 
        [SerializeField] private Item[] posibleResounces;
        [SerializeField] private ResourceAddEffect resourceAddEffect;
        
        [SerializeField] private int currentHp;
        private int maxHp;
        
        public Action<Plast> Deregister;

        public void Init(int hp)
        {
            maxHp = hp;
            currentHp = hp;
        }

        public void IsOnTop()
        {
            OnOpen();
        }
        
        protected virtual void OnOpen(){}

        protected void Heal(float healRatio)
        {
            currentHp += Mathf.RoundToInt(healRatio*maxHp);
            healthBar.SetRatio((float)currentHp/maxHp);
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        }
        
        public void Damage(int damage)
        {
            if(currentHp <= 0) return;
            
            SpawnEffect(damage);
            AddResource();
            currentHp -= damage;
            healthBar.SetRatio((float)currentHp/maxHp);
            healthBar.Show();
            spriteShaker.Shake();
            if (currentHp <= 0)
            {
                DestroyPlast();
                return;
            }
            OnDamage();
        }

        protected virtual void OnDamage(){}

        private void SpawnEffect(int damage)
        {
            Vector2 pos = effectSpawnPos.position + 
                          Vector3.right * Random.Range(-damageEffectSpread, damageEffectSpread);

            Instantiate(damageEffect, pos, quaternion.identity).Init(damage);
        }

        private void AddResource()
        {
            int amount = Random.Range(OnDamageResourceAdditionBorders.x,
                OnDamageResourceAdditionBorders.y+1);
            
            if(amount == 0) return;
            
            Item item = posibleResounces[Random.Range(0, posibleResounces.Length)];
            
            Vector2 pos = effectSpawnPos.position + 
                          Vector3.right * Random.Range(-damageEffectSpread, damageEffectSpread);

            Instantiate(resourceAddEffect, pos, quaternion.identity).Init(item, amount);
            
            Inventory.Instance.Add(item, amount);
        }
        
        private void DestroyPlast()
        {
            SoundManager.Instance.PlayPlastDestroy(destroyVolume);
            collider2D.enabled = false;
            spriteShaker.Press(destroyDelay);
            
            int resourcesAmount = Random.Range(OnDestroyResourceAdditionBorders.x,
                OnDestroyResourceAdditionBorders.y+1);

            for (int i = 0; i < resourcesAmount; i++)
            {
                AddResource();
            }
            
            Deregister?.Invoke(this);
            
            Destroy(gameObject, destroyDelay);
        }
    }
}
