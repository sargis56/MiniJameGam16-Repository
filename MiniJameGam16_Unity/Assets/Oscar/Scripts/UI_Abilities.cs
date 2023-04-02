using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Abilities : MonoBehaviour
{
    public Image scratch;
    public Image tapeCollected;
    public Image tapeNotCollected;
    public Image wee;
    public Image business;

    public bool isTapeCollected = false;
    private bool isScratchEquipped = false;
    private bool isTapeEquipped = false;
    private bool isWeeEquipped = false;
    private bool isBusinessEquipped = false;

    private Color white = Color.white;
    private Color green = Color.green;

    //I KNOW, CODE IS REALLY UGLY, BUT IM TOO DAMN LAZY TO PROPERLY DO THIS AND ITS LATE, SO HARD CODING IT IS
    void Update()
    {
        //TAPE PICKUP TO HAVE THE ICON SHOW UP ON THE HUD
        if (isTapeCollected)
        {
            tapeNotCollected.enabled = false;
            tapeCollected.enabled = true;
        }
        if (!isTapeCollected)
        {
            tapeNotCollected.enabled = true;
            tapeCollected.enabled = false;
        }


        //SCRATCH ABILITY
        if (Input.GetKeyDown(KeyCode.Alpha1) & !isScratchEquipped)
        {
            scratch.color = green;
            isBusinessEquipped = false;
            business.color = white;
            isTapeEquipped = false;
            tapeCollected.color = white;
            tapeNotCollected.color = white;
            isWeeEquipped = false;
            wee.color = white;
            isScratchEquipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) & isScratchEquipped == true)
        {
            scratch.color = white;
            isScratchEquipped = false;
        }
        

        //TAPE ABILITY
        if (Input.GetKeyDown(KeyCode.Alpha2) & !isTapeEquipped)
        {
            tapeCollected.color = green;
            tapeNotCollected.color = green;
            isBusinessEquipped = false;
            business.color = white;
            isScratchEquipped = false;
            scratch.color = white;
            isWeeEquipped = false;
            wee.color = white;
            isTapeEquipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) & isTapeEquipped == true)
        {
            tapeCollected.color = white;
            tapeNotCollected.color = white;
            isTapeEquipped = false;
        }


        //WEE ABILITY
        if (Input.GetKeyDown(KeyCode.Alpha3) & !isWeeEquipped)
        {
            wee.color = green;
            isBusinessEquipped = false;
            business.color = white;
            isScratchEquipped = false;
            scratch.color = white;
            isTapeEquipped = false;
            tapeCollected.color = white;
            tapeNotCollected.color = white;
            isWeeEquipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) & isWeeEquipped == true)
        {
            wee.color = white;
            isWeeEquipped = false;
        }


        //BUSINESS ABILITY
        if (Input.GetKeyDown(KeyCode.Alpha4) & !isBusinessEquipped)
        {
            business.color = green;
            isWeeEquipped = false;
            wee.color = white;
            isScratchEquipped = false;
            scratch.color = white;
            isTapeEquipped = false;
            tapeCollected.color = white;
            tapeNotCollected.color = white;
            isBusinessEquipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) & isBusinessEquipped == true)
        {
            business.color = white;
            isBusinessEquipped = false;
        }
    }
}
