using GroundScripts.LevelScripts.Controls;
using InventoryScripts;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/UnbuiltFloor", fileName = "UnbuiltFloor")]
    public class UnbuiltFloorState : LevelState
    {
        [SerializeField] private LevelState builtFloorState;

        private LevelPriceControl priceControl;
        
        protected override void OnInit()
        {
            controls.Level.TryGetComponent(out priceControl);
            if (priceControl == false)
            {
                Debug.LogError($"Level: {controls.Level.name} has no <b>LevelPriceControl</b> Component");
            }
        }

        public override void Update()
        {
            if (isActive == false) return;
            bool isEnought = Inventory.Instance.GetBonAmount() >= priceControl.Price;
            PlayerUI.Instance.UnbuiltUI.SetPrice(priceControl.Price, isEnought);
        }

        protected override void OnVisit()
        {
            PlayerUI.Instance.UnbuiltUI.Show(true);
            bool isEnought = Inventory.Instance.GetBonAmount() >= priceControl.Price;
            PlayerUI.Instance.UnbuiltUI.SetPrice(priceControl.Price, isEnought);
            PlayerUI.Instance.UnbuiltUI.OnTryBuild += TryBuild; 
        }

        private void TryBuild()
        {
            int price = priceControl.Price;
            if (price <= Inventory.Instance.GetBonAmount())
            {
                Inventory.Instance.RemoveBon(price);
                MineBuildHandler.Instance.Build();
                ChangeState(builtFloorState);
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
