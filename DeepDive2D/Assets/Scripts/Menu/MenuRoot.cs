using UI;
using UnityEngine;
using TMPro;

namespace Menu
{
    public class MenuRoot : MonoBehaviour
    {
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private MenuError error;
        [SerializeField] private TMP_InputField inputField;
        
        private void Awake()
        {
            soundManager.Init();
        }

        public void StartGame()
        {
            string playerName = inputField.text;
            if (playerName == "")
            {
                error.Show();
                return;
                
            }
            
        }
    }
}
