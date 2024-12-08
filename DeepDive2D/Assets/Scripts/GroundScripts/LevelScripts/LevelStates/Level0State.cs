using BuildingScripts;
using InventoryScripts;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/Level0State", fileName = "Level0State")]
    public class Level0State : BuildingLevelState
    {
        [SerializeField] private Item blueStone;
        
        private Lazer lazer;
        
        protected override void OnInit()
        {
            lazer = GetComponentInLevel<Lazer>();
            PlayerUI.Instance.SetDiggingUI(false);
        }

        public override void Update()
        {
            if(isActive == false) return;
            
            PlayerUI.Instance.LazerUI.SetAvalable(Inventory.Instance.HasItemIn(blueStone));
        }

        public override void OnChange()
        {
            PlayerUI.Instance.LazerUI.Show(false);
        }

        protected override void OnVisit()
        {
            PlayerUI.Instance.LazerUI.Show(true);
            PlayerUI.Instance.SetDiggingUI(false);
            PlayerUI.Instance.SetMoveUI(true);
            PlayerUI.Instance.LazerUI.SetAvalable(Inventory.Instance.HasItemIn(blueStone));

            PlayerUI.Instance.LazerUI.OnUpgrade += Upgrade;
        }

        private void Upgrade()
        {
            if (Inventory.Instance.HasItemIn(blueStone))
            {
                Inventory.Instance.Remove(blueStone);
                lazer.Upgrade();
            }
        }

        protected override void OnExit()
        {
            PlayerUI.Instance.LazerUI.Show(false);
            PlayerUI.Instance.LazerUI.OnUpgrade -= Upgrade;
        }
    }
}
