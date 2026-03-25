using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The player controller handles jumping and horizontal movment
/// With additional functionality for jumping and falling
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("MOVEMENT")] public float moveSpeed = 8f;
    public float jumpForce = 14f;

    [Header("GROUND CHECK")] public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;


    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;


    private PlayerInputActions input;
    private Vector2 moveInput;
    private bool jumpPressed;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        input = new PlayerInputActions();

        input.Player.Move.performed += context => moveInput = context.ReadValue<Vector2>();
        input.Player.Move.canceled += context => moveInput = Vector2.zero;
        input.Player.Jump.performed += context => jumpPressed = true;
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );


        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }


        // Jump
        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        jumpPressed = false;

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
