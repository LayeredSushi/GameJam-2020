using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    public GameState gs;
    protected Rigidbody2D rb;
    public int maxhp;
    int currenthp;

    [SerializeField]
    GameObject healEffect, deathEffect;

    Animator animator;

    [SerializeField]
    protected AudioManager audioManager;

    [SerializeField]
    GameObject redText, greenText;
	public void SuperStart()
	{
        audioManager = AudioManager.GetInstance();
        animator = GetComponent<Animator>();
        currenthp = maxhp;
	}
	public void OnFireballHit()
    {
        /*hp--;
        if(hp == 0)
        {
            Destroy(gameObject);
        }*/
    }

    public void DealDamage(int damage)
	{
        

        if (damage >= 0)
        {

            FloatingText floatingText = Instantiate(redText, transform.position, Quaternion.identity, transform).GetComponentInChildren<FloatingText>();
            //Debug.Log("damage");
            animator.Play("damage");
           
            floatingText.SetText(damage + "");
            if ((currenthp - damage) <= 0)
            {
                
                gs.score += 100;
                Die();
            }
            else
            {
                audioManager.PlayPunch();
                currenthp -= damage;
            }
        }
        else
        {
            FloatingText floatingText = Instantiate(greenText, transform.position, Quaternion.identity, transform).GetComponentInChildren<FloatingText>();
            Instantiate(healEffect, transform.position, Quaternion.identity, transform);
            audioManager.PlayHealing();
            floatingText.SetText(damage*-1 + "");
            if (maxhp < (currenthp - damage))
                currenthp = maxhp;
            else
                currenthp -= damage; 
        }   
	}

    void Die()
	{
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject); 
	}


}
