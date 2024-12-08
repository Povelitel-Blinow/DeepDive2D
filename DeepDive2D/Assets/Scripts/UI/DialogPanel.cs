using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DialogPanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private DialogPanel dialogPanel;
        public void OnPointerClick(PointerEventData eventData)
        {
            gameObject.SetActive(false);
            
            if(dialogPanel!= null)
                dialogPanel.Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
