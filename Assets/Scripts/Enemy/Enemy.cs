using System;
using UnityEngine;
using UnityHFSM;

namespace Survival
{
    [RequireComponent(typeof(Animator))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        protected float Speed;
        
        protected Transform TargetTransform;
        protected Animator Animator;
        protected StateMachine StateMachine;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        public void Initialize(Transform targetTransform)
        {
            TargetTransform = targetTransform;
            CreateStateMachine();
        }

        private void Update()
        {
            StateMachine.OnLogic();
        }

        protected abstract void CreateStateMachine();
    }
}