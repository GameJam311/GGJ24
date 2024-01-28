using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject puff;

    AudioSource audioSource;
    private Animator animator;
    public AudioClip[] footSteps;
    public AudioClip changeSound;
    public float footStepSpeed;

    public bool inLight = false;
    public float inLightTime = 0f;

    public GameObject criticScreen;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        criticScreen.SetActive(false);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FootSteps());
        groundCheck = transform.Find("GroundCheck");
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

        if (Input.GetKeyDown(KeyCode.Space))
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

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && amiCloawn!)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(changeSound, 1f);
            if (!amiCloawn)
            {
                
                amiCloawn = true;
                isClown = false;
                animator.SetBool("clowning", true);
                Instantiate(puff,transform.position,Quaternion.identity);
            }
            else
            {
                
                amiCloawn = false;
                isClown = true;
                animator.SetBool("clowning", false);
                Instantiate(puff, transform.position, Quaternion.identity);
            }
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (IsGrounded() && horizontal != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else if(IsGrounded() && horizontal == 0)
        {
            animator.SetBool("isRunning", false);
        }
        //if(rb.velocity.y > 0)
        //{
        //    animator.SetTrigger("isJumping");
        //    StartCoroutine(mýnakoyum());  
        //}
        LaughControl();
    }
    void LaughControl()
    {
        if (amiCloawn )
        {
            LaughBar.laughLevel += Time.deltaTime * 20;
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
            if (!amiCloawn) {
                if (inLightTime >= 0.5f)
                {
                    criticScreen.SetActive(true);
                    if (inLightTime >= 2.5f)
                    {
                        StartCoroutine(dieplayer());
                    }
                }
            }
            else {
                inLightTime = 0f;
                criticScreen.SetActive(false);
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
    public void aymdead()
    {
        StartCoroutine (dieplayer());
    }
    IEnumerator dieplayer()
    {
        amiCloawn = true;
        Instantiate(puff, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("GAMEPLAY");
        
    }
}
