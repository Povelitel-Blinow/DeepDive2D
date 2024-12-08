using System;
using TMPro;
using UnityEngine;

namespace UI.MineUI
{
    public class UnbuiltUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buildCostRed;
        [SerializeField] private TextMeshProUGUI buildCostGreen;

        public Action OnTryBuild;
        
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }

        public void SetPrice(int price, bool isEnoght)
        {
            if (isEnoght)
            {
                buildCostRed.text = "";
                buildCostGreen.text = price.ToString();
            }
            else
            {
                buildCostRed.text = price.ToString();
                buildCostGreen.text = "";
            }
        }
        
        public void TryBuild()
        {
            OnTryBuild?.Invoke();
        }
    }
}
