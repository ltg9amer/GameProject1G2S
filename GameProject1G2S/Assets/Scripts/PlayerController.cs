using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float creepSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float jumpPower;
    private CapsuleCollider2D capsuleCollider2D;
    public CapsuleCollider2D CapsuleCollider2D => capsuleCollider2D;
    private Rigidbody2D _rigidbody2D;
    private float moveSpeed;
    private bool isDashing;
    public bool IsDashing => isDashing;
    private bool isCrouching;
    private bool isCameraLimit;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CameraLimit();
        Move();
        Jump();
        Crouch();
    }

    private void CameraLimit()
    {
        Vector3 limit = Camera.main.WorldToViewportPoint(transform.position + new Vector3(capsuleCollider2D.size.x * 0.5f, 0f));

        if (limit.x > 1f)
        {
            limit.x = 1f;
            isCameraLimit = true;
        }
        else
        {
            isCameraLimit = false;
        }

        transform.position = Camera.main.ViewportToWorldPoint(limit) - new Vector3(capsuleCollider2D.size.x * 0.5f, 0f);
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (isCrouching)
        {
            moveSpeed = creepSpeed;
        }
        else if (isDashing = !isCrouching && !isCameraLimit && move != 0 && Input.GetKey(KeyCode.LeftShift) && Stamina.currentStamina > 0f)
        {
            moveSpeed = dashSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        transform.position += new Vector3(move * moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void Jump()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, capsuleCollider2D.size.y * 0.5f + 0.1f, groundLayer);

        if (groundHit && Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;

            capsuleCollider2D.size *= new Vector2(1f, 0.5f);
            capsuleCollider2D.offset = new Vector2(0f, -0.5f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;

            capsuleCollider2D.offset = Vector2.zero;
            capsuleCollider2D.size *= new Vector2(1f, 2f);
        }
    }
}