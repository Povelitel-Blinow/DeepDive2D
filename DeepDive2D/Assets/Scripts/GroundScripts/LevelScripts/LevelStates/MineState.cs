using BuildingScripts;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/MineState", fileName = "MineState")]
    public class MineState : BuildingLevelState
    {
        private bool isActiveVisited = false;
        
        private Mine mine;
        protected override void OnInit()
        {
            mine = GetComponentInLevel<Mine>();
            mine.Build();
            PlayerUI.Instance.MineUI.SetMinedItems(mine.GetMinedItems());
        }

        public override void Update()
        {
            if(isActiveVisited == false) return;
            
            PlayerUI.Instance.MineUI.SetMinedItems(mine.GetMinedItems());
        }

        protected override void OnVisit()
        {
            isActiveVisited = true;
            PlayerUI.Instance.MineUI.OnPickUp += PickUp;
            PlayerUI.Instance.MineUI.SetMinedItems(mine.GetMinedItems());
            PlayerUI.Instance.MineUI.Show(true);
        }

        private void PickUp()
        {
            mine.PickUp();
            PlayerUI.Instance.MineUI.SetMinedItems(mine.GetMinedItems());
        }

        protected override void OnExit()
        {
            isActiveVisited = false;
            PlayerUI.Instance.MineUI.OnPickUp -= PickUp;
            PlayerUI.Instance.MineUI.Show(false);
        }
    }
}
