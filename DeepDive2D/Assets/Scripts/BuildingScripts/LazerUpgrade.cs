using UnityEngine;

namespace BuildingScripts
{
    public class LazerUpgrade : MonoBehaviour
    {
        [SerializeField] private int baseDamage;

        public int GetDamage() => baseDamage;

        public void Upgrade()
        {
            baseDamage += 1;
        }
    }
}
