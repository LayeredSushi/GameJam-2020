using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    
    public float fireRate;
    float nextFire;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private float xDisplacement;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 5f;
    public float knockbackPower = 500;

    private Animator animator;

    //public CameraShake cameraShake;

    public GameState gs;

    private bool jumpPressed;
    private bool isFalling;

    private int fireballCount;
    private bool canMove;

    private StaffChargeManager staffChargeManager;
    private BrokenStaff brokenStaff;

    public CameraShake cameraShake;
    
    [SerializeField]
    AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        staffChargeManager = GetComponent<StaffChargeManager>();
        brokenStaff = GetComponent<BrokenStaff>();
        jumpPressed = false;
        isFalling = false;
        canMove = true;

        gs.playerHP = 3;
        
    }

    void Update()
    {
        gs.playerTransform = transform;
        fireballCount = gs.fireballCount;

        

        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }

        if (jumpPressed && isFalling)
        {
            jumpPressed = false;
        }

        

        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }

		if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
		{
            if(staffChargeManager.spellCount > 0 && brokenStaff.GetActiveSpellndex() == 0)
            {
                staffChargeManager.spellCount--;
                gs.spellCount = staffChargeManager.spellCount;
                animator.Play("mc_attack");
            }
            else if(fireballCount > 0 && brokenStaff.GetActiveSpellndex() == 1)
            {
                gs.fireballCount--;
                animator.Play("mc_attack");
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GraphicsBackground");
        }

    }

    

    void FixedUpdate()
    {
        if (canMove)
        {
            xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
            animator.SetFloat("runSpeed", Mathf.Abs(rb.velocity.x));
            animator.SetFloat("jumpSpeed", Mathf.Abs(rb.velocity.y));
        }

        if (jumpPressed && isGrounded && !isFalling)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;
            jumpPressed = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !jumpPressed)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isFalling = false;
            isGrounded = true;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.Play("mc_damage");
            StartCoroutine(ApplyKnockback(collision));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isFalling = true;
        }
    }

    IEnumerator ApplyKnockback(Collision2D collision)
    {
        //canMove = false;
        animator.Play("mc_damage");
        audioManager.PlayPunch();
        cameraShake.TriggerShake();
        gameObject.layer = LayerMask.NameToLayer("Invinsible");
        Vector2 knockBackDir = (collision.gameObject.transform.position - transform.position).normalized;
        rb.AddForce(knockBackDir * 500 * (-1));

        yield return new WaitForSeconds(2f);
        //canMove = true;
        rb.velocity = Vector2.zero;
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}