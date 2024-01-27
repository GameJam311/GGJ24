using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;

    private bool isJumping;
    private bool isClown = false;
    private bool amiCloawn = false;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform canbari;

    AudioSource audioSource;
    private Animator animator;
    public AudioClip[] footSteps;
    public float footStepSpeed;

    public bool inLight = false;
    public float inLightTime = 0f;

    public GameObject criticScreen;
    private void Start()
    {
        criticScreen.SetActive(false);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FootSteps());
    }

    void Update()
    {
        if (amiCloawn)
        {
            horizontal = 0;
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        if (IsGrounded())
        {

            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpBufferCounter = 0f;
            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && amiCloawn!)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isClown)
            {
                animator.SetBool("clowning", true);
                amiCloawn = true;
                isClown = false;
            }
            else
            {
                animator.SetBool("clowning", false);
                amiCloawn = false;
                isClown = true;
            }
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        LaughControl();
    }
    void LaughControl()
    {
        if (inLight)
        {
            LaughBar.laughLevel += Time.deltaTime * 50;
        }
        else
        {
            LaughBar.laughLevel -= Time.deltaTime * 50;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
    private IEnumerator FootSteps()
    {
        while (true)
        {
            if (IsGrounded() && horizontal != 0)
            {
                audioSource.PlayOneShot(footSteps[Random.Range(0, footSteps.Length)], 1f);
            }
            yield return new WaitForSeconds(footStepSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            inLight = true;
            inLightTime += Time.deltaTime;

            if (inLightTime >= 0.5f)
            {
                criticScreen.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            inLight = false;
            inLightTime = 0f;
            criticScreen.SetActive(false);
        }
    }
}
