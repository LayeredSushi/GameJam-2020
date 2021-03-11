using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ogre : Enemy
{
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;
    public float enemyOffset;
    private Vector2 movementDirection;

    private bool isGrounded;
    private bool isFalling;
    private bool canMove;

    private Animator animator;

    public CameraShake cameraShake;


    void Start()
    {
        SuperStart();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isGrounded = false;
        canMove = true;

        audioManager.PlayOgre();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }

        if (gs.playerTransform.position.x < transform.position.x)
        {
            movementDirection = Vector2.left;
        }
        else
        {
            movementDirection = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x < maxSpeed && canMove)
        {
            rb.AddForce(movementDirection * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" && isGrounded && !isFalling && gs.playerTransform.position.y > transform.position.y + enemyOffset)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            isFalling = false;
        }

        if (collision.gameObject.tag == "Player")
        {
            if (gs.playerHP > 0)
            {
                gs.playerHP--;
            }
            else
            {
                //Time.timeScale = 0f;
            }
            StartCoroutine(StartAttackingCoroutine());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
            isFalling = true;
        }
    }

    IEnumerator StartAttackingCoroutine()
    {
        animator.Play("ogre_attack");
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }

    public void startCameraShake()
    {
        cameraShake.TriggerShake();
    }
}
