using GroundScripts.LevelScripts;
using GroundScripts.LevelScripts.LevelStates;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Level[] levels;

        [SerializeField] private int startIndex;
        private int currentIndex;
        private Level currentLevel;
        
        public static Ground Instance { get; private set; }

        public void Init()
        {
            Instance = this;
            SetupAllLevels();
            ChangeLevel(startIndex);
        }

        private void SetupAllLevels()
        {
            foreach (Level l in levels)
            {
                l.Init();
            }
        }

        private void ChangeLevel(int index)
        {
            index = Mathf.Clamp(index, 0, levels.Length-1);

            if(currentLevel != null)
                currentLevel.OnLevelStateFinished -= ChangeCurrentLevelState;
            
            currentIndex = index;
            currentLevel = levels[index];
            Player.Instance.ChangeState(currentLevel.GetPlayerState());
            Player.Instance.MoveTo(currentLevel);
            currentLevel.OnLevelStateFinished += ChangeCurrentLevelState;
        }

        private void ChangeCurrentLevelState()
        {
            Player.Instance.ChangeState(currentLevel.GetPlayerState());
        }

        public void UpdateGround()
        {
            foreach (Level l in levels)
            {
                l.UpdateLevel();
            }
        }

        public void MoveVertical(int dir)
        {
            var nextLevel = GetLevelByIndex(currentIndex - dir);

            if(currentLevel.GetLevelType() == LayerType.UnDugged 
               && nextLevel.GetLevelType() == LayerType.UnDugged) return;
            
            if (nextLevel != currentLevel && nextLevel.GetLevelType() != LayerType.CantBeVisited)
            {
                ChangeLevel(currentIndex - dir);
            }
        }

        private Level GetLevelByIndex(int index)
        {
            index = Mathf.Clamp(index, 0, levels.Length-1);
            
            return levels[index];
        }
    }
}
