using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public BrokenStaff brokenStaff;
    private int activeSpellIndex;
    private Image[] weaponImages;
    private Image activeImage;

    public SpriteRenderer[] staffRenderers;
    public Sprite test;

    public GameState gs;

    private Color blackedOut;
    void Start()
    {
        blackedOut.a = 1f;

        weaponImages = GetComponentsInChildren<Image>();
        foreach(Image image in weaponImages)
        {
            image.enabled = false;
        }
        activeImage = weaponImages[0];
        activeImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        activeSpellIndex = brokenStaff.GetActiveSpellndex();
        ChangeImage(activeSpellIndex);

        if (gs.staffChargeState == StaffChargeManager.StaffChargeState.High)
        {
            weaponImages[0].sprite = staffRenderers[0].sprite;
        }
        else if (gs.staffChargeState == StaffChargeManager.StaffChargeState.Medium)
        {
            weaponImages[0].sprite = staffRenderers[1].sprite;
        }
        else if (gs.staffChargeState == StaffChargeManager.StaffChargeState.Low)
        {
            weaponImages[0].sprite = staffRenderers[2].sprite;
        }
    }

    private void ChangeImage(int index)
    {
        if(activeImage != weaponImages[index])
        {
            activeImage.enabled = false;
            activeImage = weaponImages[index];
            weaponImages[index].enabled = true;
        }
    }
}
