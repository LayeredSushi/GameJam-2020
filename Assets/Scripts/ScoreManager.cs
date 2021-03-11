using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameState gs;

    private void Start()
    {
        gs.score = 0;
        StartCoroutine(UpdateScore());
    }

    IEnumerator UpdateScore()
    {
        for(; ; )
        {
            gs.score += 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
