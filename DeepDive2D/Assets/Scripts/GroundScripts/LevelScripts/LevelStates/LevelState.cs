using System;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    public abstract class LevelState : ScriptableObject
    {
        [SerializeField] private LayerType type;
        public LayerType Type => type;

        public Action<LevelState> ChangeState;

        protected LevelControls controls;

        public void Init(LevelControls controls)
        {
            this.controls = controls;
            OnInit();
        }
        
        protected virtual void OnInit(){}
        
        public abstract void Update();

        public virtual void OnChange(){}

        public abstract void OnVisit();
        public abstract void OnExit();
    }

    public enum LayerType
    {
        Dugged,
        UnDugged,
        Fighting,
        CantBeVisited,
    }
}
