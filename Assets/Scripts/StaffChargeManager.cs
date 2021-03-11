using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffChargeManager : MonoBehaviour
{
    public GameState gs;

    public int spellCount;
    private float timer;
    private float fixedTimer;

    public enum StaffChargeState
    {
        Low,
        Medium,
        High
    }

    private StaffChargeState state;

    private void Start()
    {
        gs.staffChargeState = state = StaffChargeState.Low;
        gs.spellCount = spellCount = 10;
        timer = fixedTimer = 20;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < 0)
        {
            if (state == StaffChargeState.Low)
            {
                gs.staffChance = 15f;
                state = StaffChargeState.Medium;
                spellCount = 7;
            }
            else if (state == StaffChargeState.Medium)
            {
                gs.staffChance = 30f;
                state = StaffChargeState.High;
                spellCount = 5;
            }
            else if (state == StaffChargeState.High)
            {
                gs.staffChance = 80f;
            }
            timer = fixedTimer;
            gs.spellCount = spellCount;
            gs.staffChargeState = state;
        }

        timer -= 1f * Time.deltaTime;

        if (spellCount == 0)
        {
            if (state == StaffChargeState.Low)
            {
                spellCount = 10;
            }
            if (state == StaffChargeState.Medium)
            {
                gs.staffChance = 15f;
                state = StaffChargeState.Low;
                spellCount = 10;
            }
            else if (state == StaffChargeState.High)
            {
                gs.staffChance = 30f;
                state = StaffChargeState.Medium;
                spellCount = 7;
            }

            gs.spellCount = spellCount;
            gs.staffChargeState = state;
        }
    }
}
