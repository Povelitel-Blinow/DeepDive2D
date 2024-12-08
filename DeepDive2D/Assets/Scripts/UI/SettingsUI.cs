using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public static float volume = 1;
        
        public void Save()
        {
            volume = slider.value;
        }

        public void Show(bool state)
        {
            slider.value = volume;
            gameObject.SetActive(state);
        }

        public void LeaveGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
