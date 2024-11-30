using System;
using PlayerScripts.StateMachine.States;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    public abstract class LevelState : ScriptableObject
    {
        [SerializeField] private PlayerState playerState;
        public PlayerState PlayerState => playerState;

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
    }

    public enum LayerType
    {
        Dugged,
        UnDugged,
        Fighting,
        CantBeVisited,
    }
}
