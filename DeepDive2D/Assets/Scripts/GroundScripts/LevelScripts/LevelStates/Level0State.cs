using BuildingScripts;
using InventoryScripts;
using PlayerScripts;
using UnityEngine;

namespace GroundScripts.LevelScripts.LevelStates
{
    [CreateAssetMenu(menuName = "LevelStates/Level0State", fileName = "Level0State")]
    public class Level0State : LevelState
    {
        [SerializeField] private Item blueStone;
        
        private bool isActive = false;
        private Lazer lazer;
        
        protected override void OnInit()
        {
            controls.Level.TryGetComponent(out lazer);
            if (lazer == null)
            {
                Debug.LogError($"Level: {controls.Level.name} has no <b>Lazer</b> Component");
            }
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

        public override void OnVisit()
        {
            PlayerUI.Instance.LazerUI.Show(true);
            PlayerUI.Instance.SetMoveUI(true);
            isActive = true;
            PlayerUI.Instance.LazerUI.SetAvalable(Inventory.Instance.HasItemIn(blueStone));

            PlayerUI.Instance.LazerUI.OnUpgrade += Upgrade;
        }

        private void Upgrade()
        {
            if (Inventory.Instance.HasItemIn(blueStone))
            {
                Debug.Log(1111);
                Inventory.Instance.Remove(blueStone);
                lazer.Upgrade();
            }
        }
        
        public override void OnExit()
        {
            PlayerUI.Instance.LazerUI.Show(false);
            isActive = false;
            PlayerUI.Instance.LazerUI.OnUpgrade -= Upgrade;
        }
    }
}
