using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource soundtrack;
    public AudioSource fireball, spell, poof, punch, collected, healing, nofireball, firecrackles;
    public AudioSource[] ogre;

    int ogreCount;
    private static AudioManager instance;

    private void Awake()
	{
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject.GetComponent<AudioManager>();
        else
            Destroy(gameObject);
    }

	private void Start()
	{
        PlayMusic();
        ogreCount = 0;
	}

    public static AudioManager GetInstance()
    {
        return instance;
    }
    public void PlayMusic()
    {
        soundtrack.enabled = true;
        if (!soundtrack.isPlaying)
        {
            soundtrack.Play();
        }
    }

    public void PlayOgre()
	{
        if (!ogre[ogreCount].isPlaying)
        {
            ogre[ogreCount].Play();
        }
        
        ogreCount++;
	}

    public void PlayFireBall()
    {
        fireball.enabled = true;
        if (!fireball.isPlaying)
        {
            fireball.Play();
        }
    }
    public void PlaySpell()
    {
        spell.enabled = true;
        if (!spell.isPlaying)
        {
            spell.Play();
        }
    }
    public void PlayPoof()
    {
        poof.enabled = true;
        if (!poof.isPlaying)
        {
            poof.Play();
        }
    }
    public void PlayPunch()
    {
        punch.enabled = true;
        if (!punch.isPlaying)
        {
            punch.Play();
        }
    }
    public void PlayCollected()
    {
        collected.enabled = true;
        if (!collected.isPlaying)
        {
            collected.Play();
        }
    }
    public void PlayHealing()
    {
        healing.enabled = true;
        if (!healing.isPlaying)
        {
            healing.Play();
        }
    }
    public void PlayNofireball()
    {
        nofireball.enabled = true;
        if (!nofireball.isPlaying)
        {
            nofireball.Play();
        }
    }
    public void PlayFirecrackles()
    {
        firecrackles.enabled = true;
        if (!firecrackles.isPlaying)
        {
            firecrackles.Play();
        }
    }
  
}
