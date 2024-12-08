using UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuRoot : MonoBehaviour
    {
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private MenuError error;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private ApiReader apiReader;
        
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

            SceneManager.LoadScene(1);
            
            return;
            apiReader.GetPlayer(playerName);
        }
    }
}
