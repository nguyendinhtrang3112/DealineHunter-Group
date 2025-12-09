using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public Transform groundCheck;
    public Transform wallCheck;

    public float moveSpeed = 3f;
    public float jumpForce = 10f; 
    public float chaseDistance = 20f;

    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;
        float dist = Vector2.Distance(transform.position, player.position);

        // 2. Kiểm tra chạm đất
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (dist <= chaseDistance)
        {
            MoveTowardPlayer();
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("TeacherWalking", false);
        }
        animator.SetBool("TeacherJumping", !isGrounded);
    }

    void MoveTowardPlayer()
    {
        float directionX = Mathf.Sign(player.position.x - transform.position.x);
        bool hittingWall = Physics2D.OverlapCircle(wallCheck.position, 0.2f, groundLayer);

        float currentJumpSpeed = rb.linearVelocity.y;
        if (hittingWall && isGrounded)
        {
            currentJumpSpeed = jumpForce;
        }

        // MOVEMENT: Luôn gán vận tốc X để lao về phía trước (kể cả khi đang nhảy)
        rb.linearVelocity = new Vector2(directionX * moveSpeed, currentJumpSpeed);

        animator.SetBool("TeacherWalking", true);

        // Flip sprite (Lật hình)
        transform.localScale = new Vector3(directionX, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();

            if (gm != null)
            {
                gm.GameOver();
            }
            else
            {
                Debug.LogError("Không tìm thấy GameManager!");
            }
        }
    }
}