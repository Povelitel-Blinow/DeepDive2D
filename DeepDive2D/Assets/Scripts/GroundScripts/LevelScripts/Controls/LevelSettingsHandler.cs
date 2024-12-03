using UnityEngine;

namespace GroundScripts.LevelScripts.Controls
{
    public class LevelSettingsHandler : MonoBehaviour
    {
        [Header("Plast Settings")] 
        [SerializeField] private int basePlastHealth;
        [SerializeField] private float plastHealthIncreaseRatio;

        public int BaseHealth => basePlastHealth;
        public float HealthIncreaseRatio => plastHealthIncreaseRatio;
    }
}
