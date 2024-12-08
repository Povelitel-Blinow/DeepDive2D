using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    public abstract class BuildingLevelState : LevelState
    {
        public T GetComponentInLevel<T>()
        {
            controls.Level.TryGetComponent(out T component);
            if (component == null)
            {
                Debug.LogError($"Level: {controls.Level.name} has no <b>{typeof(T)}</b> Component");
            }

            return component;
        }
    }
}
