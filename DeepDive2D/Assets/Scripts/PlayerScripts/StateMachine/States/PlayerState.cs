using UnityEngine;

namespace PlayerScripts.StateMachine.States
{
    public abstract class PlayerState : ScriptableObject
    {
        public virtual void Init(){}

        public abstract void Update();
    }
}
