using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    private Transform[] spawnUnits;
    private System.Random rand;

    public float timer;
    public float fixedTimer;
    public Spell spellPrefab;
    public GameState gs;

    private bool isSpawned;

    private void Start()
    {
        gs.fireballCount = 0;
        fixedTimer = 200;
        timer = fixedTimer;
        spawnUnits = GetComponentsInChildren<Transform>();
        gs.spellSpawned = isSpawned = false;

        rand = new System.Random();
    }

    private void Update()
    {
        if (timer < 0 && !isSpawned)
        {
            int spawnUnitIndex = rand.Next(1, spawnUnits.Length);
            Instantiate(spellPrefab, spawnUnits[spawnUnitIndex]);
            timer = fixedTimer;

            gs.spellSpawned = isSpawned = true;
        }

        isSpawned = gs.spellSpawned;
        timer -= 0.1f;
    }
}
