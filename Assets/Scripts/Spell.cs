using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameState gs;

    AudioManager audioManager;
	private void Start()
	{
        audioManager = AudioManager.GetInstance();
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gs.fireballCount += 3;
            gs.spellSpawned = false;
            audioManager.PlayCollected();
            Destroy(gameObject);
        }
    }
}
