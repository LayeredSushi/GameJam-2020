using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameState gs;
    private int playerHp;
    public InGameMenuUI menuUI;
    public WeaponUIManager weaponUI;

    Text[] uiTexts;
    Image[] hpImages;
    void Start()
    {
        playerHp = 0;
        uiTexts = GetComponentsInChildren<Text>();
        hpImages = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        uiTexts[0].text = "Score: " + gs.score.ToString();
        uiTexts[1].text = gs.spellCount.ToString();
        uiTexts[2].text = gs.fireballCount.ToString();

        if(playerHp != gs.playerHP)
        {
            playerHp = gs.playerHP;
            SetHp();
        }
        if(gs.playerHP == 0)
        {
            menuUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
            weaponUI.gameObject.SetActive(false);
            Time.timeScale = 0.0001f;
        }
    }

    private void SetHp()
    {
        foreach(Image image in hpImages)
        {
            image.enabled = false;
        }

        for(int i = 0; i < gs.playerHP; i++)
        {
            hpImages[i].enabled = true;
        }
    }
}
