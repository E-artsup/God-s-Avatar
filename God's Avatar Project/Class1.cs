using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IA_Chauve_Souris
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State State;

        public void SetState(State state);
        
    }
}
