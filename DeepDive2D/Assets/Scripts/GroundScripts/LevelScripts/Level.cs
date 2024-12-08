using System;
using GroundScripts.LevelScripts.Controls;
using GroundScripts.LevelScripts.LevelStates;
using UnityEngine;

namespace GroundScripts.LevelScripts
{
    public class Level : MonoBehaviour
    {
        [Header("Controls")] 
        [SerializeField] private LevelControls controls;
        
        [Header("Settings")]
        [SerializeField] private LevelState defaultState;
        [SerializeField] private Transform cameraPos;
        
        private LevelState currentState;

        public Action OnLevelStateFinished;
        
        public LayerType GetLevelType() => currentState.Type;
        public Transform GetCameraTransform() => cameraPos;
        
        public void Init()
        {
            ChangeState(defaultState);
        }

        public void UpdateLevel()
        {
            currentState.Update();
        }

        public void OnLevelVisit()
        {
            currentState.Visit();
        }
        
        public void OnLevelExit()
        {
            currentState.Exit();
        }

        private void ChangeState(LevelState state)
        {
            bool stateChanged = false;
            if (currentState != null)
            {
                currentState.ChangeState -= ChangeState;
                currentState.OnChange();
                Destroy(currentState);
                stateChanged = true;
            }

            currentState = Instantiate(state);
            currentState.Init(controls);
            currentState.ChangeState += ChangeState;
            currentState.Visit();
            
            if(stateChanged)
                OnLevelStateFinished?.Invoke();
        }
    }

    [System.Serializable]
    public class LevelControls
    {
        public PlastsHandler plasts;
        public LevelSettingsHandler settings;
        public Level Level;
    }
}
