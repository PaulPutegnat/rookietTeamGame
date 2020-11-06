using System.Collections;
using UnityEngine;

public class T9_PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float smooth = 0.1f;
	[SerializeField] private LayerMask ground;
	[SerializeField] private Transform groundCheck;

	private bool isGrounded = false;
	private bool right = true;
    private Vector3 v0 = Vector3.zero;
	private bool dbr = false;
    private Rigidbody2D rb = null;
	private Animator animator;

    [SerializeField] float speed = 10f;

	[HideInInspector] public bool dashing = false;
	[HideInInspector] public bool isDashingBack = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
	}

	private void FixedUpdate()
	{
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, ground);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				isGrounded = true;
				dashing = false;

				if (!dbr)
					isDashingBack = false;
			}
		}

		if (!isDashingBack)
			dbr = false;

		float horizontal = Input.GetAxisRaw("Horizontal") * speed;

		bool jump = Input.GetButtonDown("Jump");

		Move(horizontal * Time.fixedDeltaTime, jump);
	}

	public void Move(float move, bool jump)
	{
		if (!dashing || !isDashingBack)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref v0, smooth);

			if ((move > 0 && !right) || (move < 0 && right))
			{
				Flip();
			}
		}

		if (isGrounded && jump)
		{
			isGrounded = false;
			rb.AddForce(new Vector2(0f, jumpForce));
		}
		else if (!isGrounded && jump && !isDashingBack && !dashing)
		{
			rb.velocity = new Vector2(0f, 0f);
			StartCoroutine("DashBack");
		}
	}

	private void Flip()
	{
		right = !right;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	IEnumerator DashBack()
	{
		rb.gravityScale = 0f;
		dashing = true;
		isDashingBack = true;

		yield return new WaitForSeconds(0.5f);

		rb.gravityScale = 1f;

		RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, -Vector2.up);

		if (hit.collider != null && hit.collider.gameObject.CompareTag("PressurePlate"))
			dbr = true;

		rb.AddForce(new Vector2(0f, -jumpForce));
	}
}
