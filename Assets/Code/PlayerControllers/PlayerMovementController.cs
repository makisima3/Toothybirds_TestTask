using System;
using Code.InteractableObjects;
using Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Code.PlayerControllers
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private PlayerAnimator animator;
        [SerializeField] private Button jumpButton;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private Transform playerView;
        [SerializeField] private Transform camera;
        
        
        [Space]
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight = 1f;
        
        private CharacterController _characterController;
        
        private bool _groundedPlayer;
        private Vector3 _playerVelocity;
        private float _gravityValue = -9.81f;

        private Platform lastPlatform;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            jumpButton.onClick.AddListener(Jump);
        }
        

        void Update()
        {
            PlatformChek();
            
            _groundedPlayer = _characterController.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            var direction = camera.forward * joystick.Vertical +
                            camera.right * joystick.Horizontal;
            _characterController.Move(direction * Time.deltaTime * speed);
            animator.ControlledAnimator.speed = direction.magnitude;
            
            if (direction != Vector3.zero)
            {
                playerView.rotation = ExtraMathf.GetRotation(direction, Vector3.up);
          //      playerView.forward = direction;
                //transform.forward = direction;
                animator.Activate(PlayerAnimator.Keys.Run);
            }

            if (direction == Vector3.zero)
            {
                animator.Deactivate(PlayerAnimator.Keys.Run);
                animator.ControlledAnimator.speed = 1f;
            }

            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        private void Jump()
        {
            var isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
            if (isGrounded)
            {
                _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * _gravityValue);
            }
        }

        private void PlatformChek()
        {
            if (Physics.Raycast(groundCheck.position, Vector3.down,out var hitInfo, 0.1f))
            {
                if (hitInfo.transform.TryGetComponent<Platform>(out var platform))
                {
                    transform.SetParent(platform.transform);
                }
                else
                {
                   
                    transform.SetParent(null);
                }
            }
            else
            {
                transform.SetParent(null);
            }
        }

    }
}