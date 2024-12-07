using System;
using TMPro;
using UnityEngine;

namespace UI.MineUI
{
    public class UnbuiltMineUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buildCost;

        public Action OnTryBuild;
        
        public void Show(bool state)
        {
            buildCost.text = MineBuildHandler.Instance.GetPrice().ToString();
            gameObject.SetActive(state);
        }
        
        public void TryBuild()
        {
            OnTryBuild?.Invoke();
        }
    }
}
