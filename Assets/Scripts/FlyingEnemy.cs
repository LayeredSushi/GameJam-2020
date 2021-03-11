using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed;
    private Vector2 movementDirectionX, movementDirectionY;
    private bool canMove;

    void Start()
    {
        SuperStart();
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
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
            movementDirectionX = Vector2.left;
        }
        else
        {
            movementDirectionX = Vector2.right;
        }

        if (gs.playerTransform.position.y < transform.position.y)
        {
            movementDirectionY = Vector2.down;
        }
        else
        {
            movementDirectionY = Vector2.up;
        }

        if(canMove)
            transform.Translate(movementDirectionX * speed * Time.deltaTime + movementDirectionY * speed * Time.deltaTime);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
            StartCoroutine(StopMovingCoroutine());
        }
    }

    IEnumerator StopMovingCoroutine()
    {
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }
}
