using System.Collections.Generic;
using GroundScripts.LevelScripts.Controls.Plasts;
using UnityEngine;

namespace GroundScripts.LevelScripts.Controls
{
    public class PlastsHandler : MonoBehaviour
    {
        [SerializeField] private List<Plast> plasts;

        public bool GetLevelIsDugged() => plasts.Count == 0;

        public void Init()
        {
            foreach (Plast p in plasts)
            {
                p.Deregister += Deregister;
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
