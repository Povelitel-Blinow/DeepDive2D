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
        protected bool isActive;

        public void Init(LevelControls controls)
        {
            this.controls = controls;
            OnInit();
        }
        
        protected virtual void OnInit(){}
        
        public abstract void Update();

        
        public virtual void OnChange(){}

        public void Visit()
        {
            isActive = true;
            OnVisit();    
        }

        protected virtual void OnVisit(){}

        public void Exit()
        {
            isActive = false;
            OnExit();
        }

        protected virtual void OnExit(){}
    }

    public enum LayerType
    {
        Dugged,
        UnDugged,
        Fighting,
        CantBeVisited,
    }
}
