using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomizerSpell : MonoBehaviour
{
    public float goodOutcomeChance;

	bool outcome;


	[SerializeField]
	float speed;
	bool canMove;

	private Rigidbody2D rb;

	[SerializeField]
	GameObject ogrePrefab, rabitPrefab, poofEffectPrefab;

	GameObject enemy;

	public GameState gs;
	System.Random rand;

	void Start()
	{
		canMove = true;
		outcome = false;
		rb = GetComponent<Rigidbody2D>();
		rand = new System.Random();
	}

    private void Update()
    {
		goodOutcomeChance = gs.staffChance;
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

	public void DoRandomEffect()
	{
		int r = rand.Next(0, 100);
		if (r <= goodOutcomeChance)
		{
			outcome = true;
		}
		else
		{
			outcome = false;
		}

		int functionNum = rand.Next(0,3);
		//Debug.Log("got an enemy");

		switch (functionNum)
		{
			case 0:
				SpawnEnemy();
				break;
			case 1:
				DealDamage();
				break;
			case 2:
				DealDamage();
				break;
		}


	}

	void SpawnEnemy()
	{
		Transform position = enemy.transform;
		GameObject spawnObject;
		
		if (outcome)
			spawnObject = rabitPrefab;
		else
			spawnObject = ogrePrefab;

		Instantiate(poofEffectPrefab, position.position, Quaternion.identity);
		Destroy(enemy);
		Instantiate(spawnObject, position.position, Quaternion.identity);

	}

	void DealDamage()
	{
		int damage = (int)Mathf.Round(Random.Range(1, 4));

		if (goodOutcomeChance > 70)
		{
			damage += 8;
		}
		else if (goodOutcomeChance > 20)
		{
			damage += 3;
		}

		if (!outcome)
				damage *= -1;

		enemy.GetComponent<Enemy>().DealDamage(damage);

	}


	

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GetComponent<Animator>().Play("exit");
		rb.velocity = Vector3.zero;
		rb.isKinematic = true;
		canMove = false;
		if (collision.gameObject.tag == "Enemy" && !collision.isTrigger)
		{
			enemy = collision.gameObject;
			DoRandomEffect();
			//DealDamage();
			//SpawnEnemy();
		}
	}

	private void DestroyItself()
	{
		Destroy(gameObject);
	}

}
