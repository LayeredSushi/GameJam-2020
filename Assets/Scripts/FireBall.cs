using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireBall : MonoBehaviour
{
	[SerializeField]
	float speed;

	[SerializeField]
	int damage;

	bool canMove;

	private Rigidbody2D rb;
	System.Random rand;


	void Start()
	{
		canMove = true;
		rand = new System.Random();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if(canMove)
			rb.velocity = transform.up * -1 * speed * Time.deltaTime;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		GetComponent<Animator>().Play("exit");
		rb.velocity = Vector3.zero;
		rb.isKinematic = true;
		canMove = false;
        if(collision.gameObject.tag == "Enemy" && !collision.isTrigger)
        {
			Enemy enemy = collision.GetComponent<Enemy>();
			enemy.DealDamage(damage+ rand.Next(0, 3));
        }
    }

	private void DestroyItself()
	{
		Destroy(gameObject);
	}
}
