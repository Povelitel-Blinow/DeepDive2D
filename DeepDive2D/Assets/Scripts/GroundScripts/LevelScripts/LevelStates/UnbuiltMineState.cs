using InventoryScripts;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/UnbuiltMine", fileName = "UnbuiltMine")]
    public class UnbuiltMineState : LevelState
    {
        [SerializeField] private LevelState builtMineState;
        
        public override void Update()
        {
            
        }

        public override void OnVisit()
        {
            PlayerUI.Instance.UnbuiltMineUI.Show(true);
            PlayerUI.Instance.UnbuiltMineUI.OnTryBuild += TryBuild;
        }

        private void TryBuild()
        {
            int price = MineBuildHandler.Instance.GetPrice();
            if (price <= Inventory.Instance.GetBonAmount())
            {
                Inventory.Instance.RemoveBon(price);
                MineBuildHandler.Instance.Build();
                ChangeState(builtMineState);
            }
        }

        public override void OnExit()
        {
            PlayerUI.Instance.UnbuiltMineUI.Show(false);
            PlayerUI.Instance.UnbuiltMineUI.OnTryBuild -= TryBuild;
        }

        public override void OnChange()
        {
            PlayerUI.Instance.UnbuiltMineUI.Show(false);
            PlayerUI.Instance.UnbuiltMineUI.OnTryBuild -= TryBuild;
        }
    }
}
