using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Task1.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputController inputController;
        private PlayerInputs playerInputs;
        private InputAction moveAction;

        [HideInInspector]
        public float moveSpeed;

        [SerializeField] private float groundDrag = 5f;

        [HideInInspector] public float jumpForce;
        [SerializeField] private float jumpCooldown = 1f;
        [SerializeField] private float airMultiplier = 0.1f;
        private bool readyToJump = true;

        [Header("Keybinds")]
        [SerializeField]
        private KeyCode jumpKey = KeyCode.Space;

        [Header("Ground Check")]
        [SerializeField] private float playerHeight = 2f;
        [SerializeField] private LayerMask whatIsGround;
        private bool grounded;

        [SerializeField] private Transform orientation;

        private float horizontalInput;
        private float verticalInput;

        private Vector3 moveDirection;

        private Rigidbody rb;

        private IPlayerStats playerStats;

        private void Start()
        {
            playerInputs = GetComponent<PlayerInputs>();
            moveAction = playerInputs.FindAction("PlayerMovement");
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;

            playerStats = GetComponent<IPlayerStats>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void Update()
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            MyInput();
            SpeedControl();

            if (grounded)
            {
                rb.drag = groundDrag;
            }
            else
            {
                rb.drag = 0;
            }
        }

        private void MyInput()
        {
            if(Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }

        private void MovePlayer()
        {
            moveDirection = moveAction.ReadValue<Vector3>();

            if (grounded)
            {
                rb.AddForce(moveDirection.normalized * playerStats.GetMovementSpeed() * 10f, ForceMode.Force);
            } else if (!grounded)
            {
                rb.AddForce(moveDirection.normalized * playerStats.GetMovementSpeed() * 10f * airMultiplier, ForceMode.Force);
            }

        }

        private void SpeedControl()
        {
            Vector2 flatVel = new Vector3(rb.velocity.x, rb.velocity.z);

            if(flatVel.magnitude > playerStats.GetMovementSpeed())
            {
                Vector3 limitedVel = flatVel.normalized * playerStats.GetMovementSpeed();
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

        private void Jump()
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * playerStats.GetJumpStrength(), ForceMode.Impulse);
        }

        private void ResetJump()
        {
            readyToJump = true;
        }
    }
}

