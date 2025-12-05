using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim; // 1. Khai báo biến Animator
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // 2. Lấy component Animator về dùng
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsWin())
        {
            return; // Nếu game over thì không cho di chuyển nữa
        }
        HandleMovement();
        UpdateAnimation(); // 3. Gọi hàm cập nhật hoạt hình liên tục
        HandleJump();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        
        // Code mới: Quay mặt nhân vật theo hướng đi
        if (moveInput > 0) // Đi phải
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0) // Đi trái
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Hàm mới: Quản lý việc chuyển đổi giữa Đứng yên và Chạy
    private void UpdateAnimation()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        // Nếu moveInput khác 0 (tức là có bấm phím) -> Thì là đang chạy (isRunning = true)
        // Nếu moveInput bằng 0 (không bấm gì) -> Thì là đứng yên (isRunning = false)
        bool isRunning = moveInput != 0; 
        
        // Gửi thông báo cho Animator biết
        anim.SetBool("isRunning", isRunning);

    
        // Kiểm tra xem nhân vật có đang chạm đất không để bật animation Nhảy
        if (isGrounded == false) 
        {
            anim.SetBool("isJumping", true); // Đang trên trời
        }
        else 
        {
            anim.SetBool("isJumping", false); // Đã chạm đất
        }
        // ----------------------------------------
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}