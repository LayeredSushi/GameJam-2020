using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaffChargeManager;

public class GameState : MonoBehaviour
{
    public Transform playerTransform;
    public int playerHP;

    public int fireballCount;
    public bool spellSpawned;

    public int score;

    public float staffChance;

    public int spellCount;
    public StaffChargeState staffChargeState;
}
