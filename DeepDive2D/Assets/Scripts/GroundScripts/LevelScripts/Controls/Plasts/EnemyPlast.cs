using UnityEngine;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class EnemyPlast : Plast
    {
        [SerializeField] private float regeneration;
        [SerializeField] private float regenDelay;

        [SerializeField] private AudioSource source;
        [SerializeField] private float volume;

        [SerializeField] private Transform scalable;
        
        private float timer = 0;

        protected override void OnOpen()
        {
            source.volume = volume;
            scalable.localScale = Vector3.one;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > regenDelay)
            {
                timer = 0;
                Heal(regeneration);
            }
        }

        protected override void OnDamage()
        {
            
        }
    }
}
