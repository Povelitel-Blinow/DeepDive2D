using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ButtonSoundManager : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SoundManager.Instance.PlayButtonClick();
        }
    }
}
