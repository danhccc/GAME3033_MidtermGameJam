using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction jumpAction;

    
    [Header("Character variables")]
    public float walkSpeed;
    public float runSpeed;
    public float rotateSpeed;
    public float jumpForce;
    public bool isWalking;
    public bool isRunning;
    public bool isJumping;
    public float aimSensitivity;
    private Vector3 startingPosition;

    [SerializeField] private float smoothInputSpeed = 0.2f;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;
    private Vector3 movementDirection;

    [Header("Components")]
    Animator animator;
    Rigidbody rigidbody;
    [SerializeField] public GameObject cameraFollowPoint;

    [Header("Movement References")]
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    [Header("Animator parameter IDs")]
    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isWalkingHash  = Animator.StringToHash("isWalking");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
    public readonly int isRunningHash = Animator.StringToHash("isRunning");

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
        jumpAction.ReadValue<float>();

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startingPosition = transform.position;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Camera X_Axis rotation
        cameraFollowPoint.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
        cameraFollowPoint.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);
        // Camera Y_Axis rotation
        var angles = cameraFollowPoint.transform.localEulerAngles;
        angles.z = 0;

        var angle = cameraFollowPoint.transform.localEulerAngles.x;

        if (angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if (angle < 180 && angle > 70)
        {
            angles.x = 70;
        }

        cameraFollowPoint.transform.localEulerAngles = angles;


        transform.rotation = Quaternion.Euler(0, cameraFollowPoint.transform.rotation.eulerAngles.y, 0);
        cameraFollowPoint.transform.localEulerAngles = new Vector3(angles.x, 0f, 0f);

        /* Character movements */
        if (isJumping)
            return;

        if (!(inputVector.magnitude > 0))
            moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        currentInputVector = Vector2.SmoothDamp(currentInputVector, moveDirection, ref smoothInputVelocity, smoothInputSpeed); ;
       
        //movementDirection = new Vector3(currentInputVector.x, 0, currentInputVector.y);
        //movementDirection.Normalize();

        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);

        /* Rotate towards moving direction */
        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        //}

    }


    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();

        if (inputVector != Vector2.zero)
        {
            isWalking = true;
            animator.SetBool(isWalkingHash, isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool(isWalkingHash, isWalking);
        }

        animator.SetFloat(movementXHash, inputVector.x);
        animator.SetFloat(movementYHash, inputVector.y);
    }

    public void OnRun(InputValue value)
    {
        isRunning = value.isPressed;
        animator.SetBool(isRunningHash, isRunning);
    }

    public void OnJump(InputValue value)
    {
        if (isJumping)
            return;

        isJumping = true;
        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        animator.SetBool(isJumpingHash, isJumping);
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
        // If we aim up, down, adjust animations to have a mask that will let us properly animate aim

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !isJumping)
            return;
        isJumping = false;
        animator.SetBool(isJumpingHash, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            resetPosition();
        }
    }

    private void resetPosition()
    {
        transform.position = startingPosition;
    }
}
