using System;
using UnityEngine;

namespace GroundScripts.LevelScripts.Controls.Plasts
{
    public class Plast : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer SpriteRenderer;

        public Action<Plast> Deregister;
        
        public void DestroyPlast()
        {
            Deregister?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
