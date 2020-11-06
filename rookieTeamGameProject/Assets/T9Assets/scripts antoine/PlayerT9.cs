using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerT9 : MonoBehaviour
{
    public float speed = 7f;                        // Vitesse du joueur
    private Vector3 vecRef = Vector3.zero;
    [Range(0f, 0.3f)] [SerializeField] private float smooth = 0.1f;
    private float horizontal;
    public event System.Action OnPlayerDeath;       // Sur la mort du joueur
    [HideInInspector] public bool  isJumping;
    [HideInInspector] public bool isDoubleJumping;
    public bool isGrounded;

    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundDetector;

    public GameObject wall;

    public float jumpPower = 5f;
    public float wallJumpPower = 7f;
    public float doubleJumpPower = 3f;
                                                   // Direction du joueur
    private bool right = true;
                                                     // Walljump
    public bool isOnAWall;

    bool wallSliding = false;
    public float wallSlidingSpeed;

    bool canWallJump;

    private Rigidbody2D rb;              // propriétés du dash
    public float dashSpeed;
    [SerializeField] private float dashTime;
    
    bool canDash = true;

    [HideInInspector] public bool dashing = false;

    [HideInInspector] public bool isDashingBack = false;

    public bool dbr = false;
    
    public float cooldown;

    public bool invincibility = false;

    [Header("Life")]
    [SerializeField] private List<Sprite> lifeSprite;
    [SerializeField] private List<SpriteRenderer> spriteRenderers;
    private int life = 3;
    private bool isDead = false;

    public SpriteRenderer spritePlayer;
    [SerializeField] private T9_Boss boss;

    private float gravityScale = 0f;

    private Animator animator;

    [Header("Menu")]
    [SerializeField] private T9_menu menu;
    [SerializeField] private AudioSource audioSource;
 
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    void Start()
    {
        gravityScale = rb.gravityScale;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            Jump();
            Dash();

            horizontal = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            bool wasGrounded = isGrounded;
            isGrounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundDetector.position, 0.2f, ground);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;

                    if (!wasGrounded)
                        OnLandEvent.Invoke();

                    dashing = false;


                    if (!dbr)
                        isDashingBack = false;
                }
            }

            if (!isDashingBack)
                dbr = false;


            if (isGrounded == false && !isDashingBack && canDash && Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine("DashBack");
            }

            if (isGrounded == true)
            {
                dashing = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
            Movement(horizontal * speed * Time.fixedDeltaTime);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDashingBack", false);
    }

    public void BonusType(int type)
    {
        if (type == 0) // Invincibility
        {
            StartCoroutine(Invicibility());
        }
        else if (type == 1) // Heal
        {
            if (life < 3)
                Heal(1);
        }
        else if (type == 2) // Reset boss aggro
        {
            boss.ResetBossAngry();
        }
    }

    public void PlayerTakeDamage()
    {
        StartCoroutine("TakeDamage");
    }

    private void Heal(int _life)
    {
        if (!isDead)
        {
            life += _life;
            for (int i = 0; i < life; i++)
            {
                spriteRenderers[i].sprite = lifeSprite[life - 1];
                spriteRenderers[i].color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    IEnumerator TakeDamage()
    {
        spriteRenderers[life - 1].color = new Color(0.5f, 0.5f, 0.5f, 1f);

        life -= 1;

        invincibility = true;

        spritePlayer.color = new Color(0.5f, 1f, 1f, 0.5f);

        if (life <= 0)
        {
            isDead = true;
            GetComponent<AudioSource>().Play();
            menu.Lose();
            audioSource.Stop();
        }
        else
        {
            for (int i = 0; i < life; i++)
            {
                spriteRenderers[i].sprite = lifeSprite[life - 1];
            }
        }

        yield return new WaitForSeconds(1.5f);

        spritePlayer.color = new Color(1f, 1f, 1f, 1f);

        if (!isDead)
            invincibility = false;
    }

    IEnumerator Invicibility()
    {
        invincibility = true;

        spritePlayer.color = new Color(0.5f, 1f, 1f, 0.5f);

        yield return new WaitForSeconds(6f);

        spritePlayer.color = new Color(1f, 1f, 1f, 1f);

        invincibility = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Platform" && isOnAWall == false )
        {
            wall.GetComponent<Wallcheckt9>().anotherWall = true;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpPower));
            isJumping = true;
            canWallJump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && isJumping == true && isOnAWall == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, doubleJumpPower));
            isJumping = false;
            canWallJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnAWall == true  && canWallJump == true && isGrounded == false)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(-25f, wallJumpPower));
            isJumping = false;
            canWallJump = false;
            isOnAWall = false;
        }

        if(isJumping == false)
        {
            isDoubleJumping = true;   // Variable montrant juste dans l'inspecteur l'état de double jump ou wall jump
        }
    }

    void Movement(float velocity)
    {
        if(rb.gravityScale != 0f )
        {
            Vector3 Move = new Vector2(velocity*10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, Move, ref vecRef, smooth ); 
            if((right == true && velocity < 0f) || (right == false && velocity > 0f))
            {
                Flip();
            }
        }    
    }

    public void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine("DashTime");
        }
    }

    private void Flip()
    {
        right = !right;
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
    }

    IEnumerator DashTime()
    {
        animator.SetBool("IsDashing", true);

        canDash = false;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2( transform.localScale.x * dashSpeed, 0f));

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = gravityScale;
        animator.SetBool("IsDashing", false);

        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }

    IEnumerator DashBack()
	{
        animator.SetBool("IsDashingBack", true);

        rb.velocity = new Vector2(0f, 0f);
		rb.gravityScale = 0f;
		dashing = false;
		isDashingBack = true;

		yield return new WaitForSeconds(0.5f);

		rb.gravityScale = gravityScale;

		RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, -Vector2.up);

		if (hit.collider != null && hit.collider.gameObject.CompareTag("PressurePlate"))
			dbr = true;

		rb.AddForce(new Vector2(0f, -2000f));
	}
}




















    