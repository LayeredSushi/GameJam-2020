using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] spawnUnits;
    private System.Random rand;

    public float timer;
    public float fixedTimer;
    public Enemy[] enemyPrefabs;

    private void Start()
    {
        fixedTimer = 50;
        timer = 50;
        spawnUnits = GetComponentsInChildren<Transform>();
        rand = new System.Random();
    }

    private void Update()
    {
        if(timer < 0)
        {
            int spawnUnitIndex = rand.Next(1, spawnUnits.Length);
            int enemyIndex = rand.Next(0, enemyPrefabs.Length - 1);
            Enemy enemy = Instantiate(enemyPrefabs[enemyIndex], spawnUnits[spawnUnitIndex]);
            enemy.transform.parent = null;
            timer = fixedTimer;
        }

        timer -= 0.1f;
    }
}
