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

    private bool isEquipped = false;
    private Color white = Color.white;
    private Color green = Color.green;

    void Start()
    {
        //set all icon colors to default on start as they are unequipped
        scratch.color = white;
        tapeCollected.color = white;
        tapeNotCollected.color = white;
        wee.color = white;
        business.color = white;
    }
    void Update()
    {
        //on equip, change color to green, link to proper equip function, for now its linked to button press for testing purposes
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isEquipped = !isEquipped;
            scratch.color = isEquipped? green : white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isEquipped = !isEquipped;
            tapeCollected.color = isEquipped ? green : white;
            tapeNotCollected.color = isEquipped ? green : white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isEquipped = !isEquipped;
            wee.color = isEquipped ? green : white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isEquipped = !isEquipped;
            business.color = isEquipped ? green : white;
        }
    }
}
