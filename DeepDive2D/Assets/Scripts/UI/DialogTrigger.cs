using UnityEngine;

namespace UI
{
    public class DialogTrigger : MonoBehaviour
    {
        [SerializeField] private DialogPanel dialogPanel;

        private void OnDestroy()
        {
            dialogPanel.Show();
        }
    }
}
