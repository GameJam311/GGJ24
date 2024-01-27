using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FootSteps());
    }

    void Update()
    {
        if(amiCloawn)
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

        if (Input.GetButtonDown("Jump") )
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isClown)
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            StartCoroutine(increaseit());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
           StartCoroutine(decreaseit());
        }
    }
    IEnumerator increaseit()
    {
        Debug.Log("�a�r�ld�m");
        float targetScaleY = 1f;
        if (canbari.localScale.y < targetScaleY)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 newScale = new Vector2 (canbari.localScale.x,canbari.localScale.y + 0.1f);
            canbari.localScale = newScale;
            StartCoroutine(increaseit());
        }
    }
    IEnumerator decreaseit()
    {
        float targetScaleY = 0.01f;
        if(canbari.localScale.y < targetScaleY)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 newScale = new Vector2(canbari.localScale.x, canbari.localScale.y - 0.1f);
            canbari.localScale = newScale;
            StartCoroutine(decreaseit());
        }     
    }
}
