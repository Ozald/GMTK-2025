using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveDir = 0f;
    private bool pressedSpace = false;

    [Header("Setup")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;
    public Transform respawnPoint;

    [Header("Config")]
    public float movementSpeed = 5f;
    public float jumpPower = 5f;
    public float rotationSpeed = 5f;

    [Header("Abilities")]
    public bool canJump = true;
    public bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        pressedSpace = Input.GetKeyDown(KeyCode.Space);

        Collider2D ground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckMask);
        if (ground != null && canJump && pressedSpace)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void FixedUpdate()
    {
        
        if (canMove)
        {
            rb.velocity = new Vector2(moveDir * movementSpeed, rb.velocity.y);
            float speed = rb.velocity.magnitude;

            if (speed > 0.5)
            {
                transform.Rotate(-1 * moveDir * Vector3.forward * speed * rotationSpeed * Time.fixedDeltaTime);
            }
            else
            {
                transform.Rotate(0,0,0);
                rb.angularVelocity = 0;
            }

            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            transform.position = respawnPoint.position;
        }
    }
}
