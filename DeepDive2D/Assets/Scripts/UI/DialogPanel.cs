using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DialogPanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private DialogPanel dialogPanel;
        [SerializeField] private float nonClickTime;

        [SerializeField] private bool canClick = false;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if(canClick == false) return;
            
            gameObject.SetActive(false);
            
            if(dialogPanel!= null)
                dialogPanel.Show();
        }

        public void Show()
        {
            try
            {
                //No time to fix
                gameObject.SetActive(true);
                StartCoroutine(NonClicking());
            }
            catch (Exception e)
            {
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator NonClicking()
        {
            yield return new WaitForSeconds(nonClickTime);
            canClick = true;
        }
    }
}
