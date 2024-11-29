using System;
using GroundScripts.LevelScripts.LevelStates;
using PlayerScripts.StateMachine.States;
using UnityEngine;

namespace GroundScripts.LevelScripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelState defaultState;

        private LevelState currentState;
        
        public LayerType GetLevelType() => currentState.Type;
        public PlayerState GetPlayerState() => currentState.PlayerState;
        
        public void Init()
        {
            ChangeState(defaultState);
        }

        public void UpdateLevel()
        {
            
        }

        private void ChangeState(LevelState state)
        {
            if (currentState != null)
            {
                currentState.ChangeState -= ChangeState;
                currentState.OnChange();
                Destroy(currentState);
            }

            currentState = Instantiate(state);
            currentState.Init();
            currentState.ChangeState += ChangeState;
        }
    }
}
