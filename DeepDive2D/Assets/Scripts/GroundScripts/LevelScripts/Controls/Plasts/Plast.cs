using System;
using UnityEngine;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class Plast : MonoBehaviour
    {
        [SerializeField] private int hp;
        
        public Action<Plast> Deregister;

        public void Init(int hp)
        {
            this.hp = hp;
        }
        
        public void Damage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                DestroyPlast();
            }
        }
        
        private void DestroyPlast()
        {
            Deregister?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
