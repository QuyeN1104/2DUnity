using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public float acceleration = 0.1f;
    private bool grounded = true;
    public GameObject enemy;
    private Rigidbody2D body;
    private Animator anim;
    private float moveInput;
    private float smoothMoveVelocity;
    private float currentVelocityX;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        body.freezeRotation = true;
        enemy.SetActive(false);
    }

    void Update()
    {
        // Lấy input với độ mượt
        moveInput = Input.GetAxis("Horizontal");

        // Xử lý nhảy
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            grounded = false;
            AudioManager.Instance.Jump();

        }

        // Cập nhật animation
        anim.SetBool("Idle", Mathf.Abs(moveInput) < 0.01f);
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);


        if(transform.position.y < -20f)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        // Di chuyển mượt mà
        currentVelocityX = Mathf.SmoothDamp(body.linearVelocity.x, moveInput * moveSpeed, ref smoothMoveVelocity, acceleration);
        body.linearVelocity = new Vector2(currentVelocityX, body.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu nhân vật đang chạm đất
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "left")
        {
            enemy.SetActive(true);
            Debug.Log("Left");
        }
        if (collision.gameObject.CompareTag("right"))
        {
            enemy.SetActive(false);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        AudioManager.Instance.Die();
        SceneManager.LoadScene("GameOver");

    }
}
