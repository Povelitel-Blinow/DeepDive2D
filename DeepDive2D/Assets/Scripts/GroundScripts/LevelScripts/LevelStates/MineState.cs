using BuildingScripts;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/MineState", fileName = "MineState")]
    public class MineState : LevelState
    {
        private bool isActiveVisited = false;
        
        private Mine mine;
        protected override void OnInit()
        {
            controls.Level.TryGetComponent(out mine);
            if (mine == null)
            {
                Debug.LogError($"Level: {controls.Level.name} has no <b>Mine</b> Component");
            }
            mine.Build();
            PlayerUI.Instance.MineUI.SetMinedItems(mine.GetMinedItems());
        }

        public override void Update()
        {
            if(isActiveVisited == false) return;
            
            PlayerUI.Instance.MineUI.SetMinedItems(mine.GetMinedItems());
        }

        public override void OnVisit()
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

        public override void OnExit()
        {
            isActiveVisited = false;
            PlayerUI.Instance.MineUI.OnPickUp -= PickUp;
            PlayerUI.Instance.MineUI.Show(false);
        }
    }
}
