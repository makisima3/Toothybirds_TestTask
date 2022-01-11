using System;
using System.Linq;
using UnityEngine;

namespace Code.PlayerControllers
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimatorStateController<T> : MonoBehaviour
        where T: Enum
    {
        public enum StateType
        {
            Trigger,
            Bool
        }
        
        [Serializable]
        public class State<TKey>
            where TKey: Enum
        {
            [SerializeField] private TKey key;
            [SerializeField] private StateType stateType;
            [SerializeField] private string name;

            public TKey Key => key;
            public StateType StateType => stateType;
            public string Name => name;
        }

        [SerializeField] private State<T>[] states;

        private Animator _animator;


        public Animator ControlledAnimator => _animator;
        
        protected void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Activate(T key)
        {
            var state = states.FirstOrDefault(s => s.Key.Equals(key));
            if(state == null)
                return;

            if (state.StateType == StateType.Trigger)
            {
                _animator.SetTrigger(state.Name);
            }
            else if (state.StateType == StateType.Bool)
            {
                _animator.SetBool(state.Name, true);
            }
        }

        public void Deactivate(T key)
        {
            var state = states.FirstOrDefault(s => s.Key.Equals(key));
            if(state == null)
                return;
            
            if (state.StateType == StateType.Bool)
            {
                _animator.SetBool(state.Name, false);
            }
        }
    }
}