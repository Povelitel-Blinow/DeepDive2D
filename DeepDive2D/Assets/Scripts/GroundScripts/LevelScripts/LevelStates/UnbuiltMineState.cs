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
            if(isActive == false) return;
            
            bool isEnought = Inventory.Instance.GetBonAmount() >= MineBuildHandler.Instance.GetPrice();
            PlayerUI.Instance.UnbuiltUI.SetPrice(MineBuildHandler.Instance.GetPrice(), isEnought);
        }

        protected override void OnVisit()
        {
            PlayerUI.Instance.UnbuiltUI.Show(true);
            bool isEnought = Inventory.Instance.GetBonAmount() >= MineBuildHandler.Instance.GetPrice();
            PlayerUI.Instance.UnbuiltUI.SetPrice(MineBuildHandler.Instance.GetPrice(), isEnought);
            PlayerUI.Instance.UnbuiltUI.OnTryBuild += TryBuild;
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

        protected override void OnExit()
        {
            PlayerUI.Instance.UnbuiltUI.Show(false);
            PlayerUI.Instance.UnbuiltUI.OnTryBuild -= TryBuild;
        }

        public override void OnChange()
        {
            PlayerUI.Instance.UnbuiltUI.Show(false);
            PlayerUI.Instance.UnbuiltUI.OnTryBuild -= TryBuild;
        }
    }
}
