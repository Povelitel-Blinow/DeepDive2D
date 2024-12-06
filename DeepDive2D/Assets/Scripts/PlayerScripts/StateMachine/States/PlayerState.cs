using GroundScripts;
using UnityEngine;

namespace PlayerScripts.StateMachine.States
{
    public abstract class PlayerState : ScriptableObject
    {
        public virtual void Init(){}

        public abstract void Update();

        public virtual void MoveVertical(int dir)
        {
            Ground.Instance.MoveVertical(dir);
        }
    }
}
