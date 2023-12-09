using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float turnSmoothTime = 0.1f;
    public float movementSpeedMax = 4f;
    public float onRun;
    float movementSpeed = 4f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundDistance = 0.25f;
    public float maxFallZone = -100f;

    CharacterController characterController;

    public Animator animator;

    Vector3 move;
    public Vector3 velocity;
    float turnSmoothVelocity;
    float canJump = 0f;

    [HideInInspector]
    public float horizontal;
    float vertical;
    bool isGrounded;
    public LayerMask groundMask;
    public GameObject groundCheck;


    public int maxJump;
    int countJump;
    bool onGrounded;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        countJump = maxJump;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        move = new Vector3(horizontal, 0f, vertical).normalized;
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > canJump && countJump > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = Time.time + 0.3f;
            Debug.Log("Jump");

            onGrounded = false;

            countJump--;

            //Animation

            if (countJump == 1)
            {

            }
            else if (countJump == 0)
            {

            }
        }
        if (isGrounded && !onGrounded && Time.time > canJump)
        {
            onGrounded = true;
            countJump = maxJump;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
