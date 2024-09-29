using UnityEngine;
using UnityHFSM;

namespace Survival
{
    [RequireComponent(typeof(Animator))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        protected float Speed;
        
        [SerializeField]
        protected Transform TargetTransform;

        protected Animator Animator;
        
        protected StateMachine StateMachine;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            CreateStateMachine();
        }

        protected abstract void CreateStateMachine();
    }
}