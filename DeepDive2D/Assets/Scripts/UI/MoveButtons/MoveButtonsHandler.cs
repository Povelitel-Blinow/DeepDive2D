using PlayerScripts;
using UnityEngine;

namespace UI.MoveButtons
{
    public class MoveButtonsHandler : MonoBehaviour
    {
        public void Move(int dir)
        {
            Player.Instance.MoveVertical(dir);
        }
    }
}
