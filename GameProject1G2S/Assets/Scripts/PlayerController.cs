using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float creepSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float jumpPower;
    private CapsuleCollider2D capsuleCollider2D;
    private Rigidbody2D _rigidbody2D;
    private float moveSpeed;
    private bool isDashing;
    private bool isCrouching;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        Move();
        Jump();
        Crouch();
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (isCrouching)
        {
            moveSpeed = creepSpeed;
        }
        else if (isDashing = Input.GetKey(KeyCode.LeftShift))
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
        if (Input.GetKeyDown(KeyCode.W))
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
