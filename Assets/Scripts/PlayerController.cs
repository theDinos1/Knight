using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;
    private Animator _Animator;
    private static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0 || moveInput < 0)
        {
            _Animator.SetBool("IsMoving", true);
        }
        else
        {
            _Animator.SetBool("IsMoving", false);
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            Debug.Log("Jump");
            _Animator.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log("Jump");
            _Animator.SetTrigger("Jump");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") || collision.CompareTag("Deadzone"))
        {
            Die();
        }
        else if (collision.CompareTag("Goal"))
        {
            if (SceneManager.GetActiveScene().name == "Game")
                SceneManager.LoadScene("Game2");
            else UIGameManager.Instance.Win();
        }
        else if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            score++;
            Debug.Log(score);
            UIGameManager.Instance.SetUpScore(score);
        }
    }
    public static void ResetScore()
    {
        score = 0;
        UIGameManager.Instance.SetUpScore(score);
    }

    public void Die()
    {
        UIGameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}