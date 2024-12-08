using System;
using UnityEngine;

namespace UI.LazerUI
{
    public class LazerUI : MonoBehaviour
    {
        [SerializeField] private GameObject textGreen;
        [SerializeField] private GameObject textRed;
        
        public Action OnUpgrade;

        public void Upgrade()
        {
            OnUpgrade?.Invoke();
        }

        public void SetAvalable(bool state)
        {
            textGreen.SetActive(state);
            textRed.SetActive(!state);
        }

        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}
