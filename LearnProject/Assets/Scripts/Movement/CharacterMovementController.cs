﻿using UnityEngine;

namespace LearnProject.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovementController : MonoBehaviour
    {
        private static readonly float SqrEpsilon = Mathf.Epsilon*Mathf.Epsilon;

        [SerializeField]
        private float _speed = 1f;
        [SerializeField]
        private float _sprintMod = 2f;
        [SerializeField]
        private float _maxRadiusDelta = 10f;
        
        public Vector3 MovementDirection { get; set; }
        public Vector3 VisionDirection { get; set; }

        private CharacterController _characterController;


        protected void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        protected void Update()
        {
            Translate();

            if (_maxRadiusDelta > 0f && VisionDirection != Vector3.zero)
                Rotate();
        }

        private void Translate() {

            var delta = MovementDirection * _speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.Space))
                _characterController.Move(delta* _sprintMod);
            else
                _characterController.Move(delta);
        }

        private void Rotate()
        {
            var currentLookDirection = transform.rotation * Vector3.forward;
            float sqrMagnitude = (currentLookDirection - VisionDirection).sqrMagnitude;

            if (sqrMagnitude > SqrEpsilon)
            {
                var newRotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(VisionDirection, Vector3.up),
                    _maxRadiusDelta * Time.deltaTime);
                transform.rotation = newRotation;
            }
        }
    }
}