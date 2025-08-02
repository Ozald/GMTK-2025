using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveDir = 0f;
    private bool pressedSpace = false;

    [Header("Setup")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;
    public Transform respawnPoint;
    public CameraShake camera;

    [Header("Particles")]
    public ParticleSystem walkParticles;
    public ParticleSystem deathParticles;

    [Header("Config")]
    public float movementSpeed = 5f;
    public float jumpPower = 5f;
    public bool pauseMovement = true;

    [Header("Abilities")]
    public bool canJump = true;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pauseMovement = true;
        walkParticles.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        pressedSpace = Input.GetKeyDown(KeyCode.Space);

        Collider2D ground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckMask);

        if (!pauseMovement)
        {
            if (moveDir > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moveDir < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (ground != null)
            {
                if (canJump && pressedSpace)
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);

                walkParticles.enableEmission = true;
            }
            else
            {
                walkParticles.enableEmission = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (canMove && !pauseMovement)
            rb.velocity = new Vector2(moveDir * movementSpeed, rb.velocity.y);
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
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        pauseMovement = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        walkParticles.enableEmission = false;

        deathParticles.Play();
        camera.StartShake(0.2f, 0.1f);
        yield return new WaitForSeconds(1f);

        transform.position = respawnPoint.position;
        renderer.enabled = true;
        pauseMovement = false;
        rb.isKinematic = false;
    }

    public void EnableMovement()
    {
        pauseMovement = false;
    }
}
