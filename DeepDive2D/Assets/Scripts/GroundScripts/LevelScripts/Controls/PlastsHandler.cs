using System.Collections.Generic;
using GroundScripts.LevelScripts.Controls.Plasts;
using UnityEngine;

namespace GroundScripts.LevelScripts.Controls
{
    public class PlastsHandler : MonoBehaviour
    {
        [SerializeField] private List<Plast> plasts;

        public bool GetLevelIsDugged() => plasts.Count == 0;

        public void Init(int basePlastHealth, float healthIncreaseRatio)
        {
            for (int i = 0; i < plasts.Count; i++)
            {
                int hp = basePlastHealth + Mathf.RoundToInt(i * healthIncreaseRatio * basePlastHealth);
                plasts[i].Init(hp);
                plasts[i].Deregister += Deregister;
            }
        }

        private void Deregister(Plast plast)
        {
            plast.Deregister -= Deregister;
            if (plasts.Contains(plast))
            {
                plasts.Remove(plast);
            }
        }
    }
}
