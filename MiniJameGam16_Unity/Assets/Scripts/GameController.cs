using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] interactables;

    public Rules rules;

    public GameObject toothbrush;
    public GameObject rug;
    public GameObject toiletWater;
    public GameObject[] towels;
    public GameObject shampoo;

    [SerializeField]
    private int clawedTowels;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        interactables = GameObject.FindGameObjectsWithTag("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if ((toothbrush.GetComponent<ObjectController>().currentState == ObjectController.ObjectState.Clawed) && (rules.GetComponent<Rules>().win == false))
        {
            rules.GetComponent<Rules>().isToothbrushComplete = true;
        }

        if ((rug.GetComponent<ObjectController>().currentState == ObjectController.ObjectState.Duked) && (rules.GetComponent<Rules>().win == false))
        {
            rules.GetComponent<Rules>().isRugPoopComplete = true;
        }

        if ((rug.GetComponent<ObjectController>().currentState == ObjectController.ObjectState.Wet) && (rules.GetComponent<Rules>().win == false))
        {
            rules.GetComponent<Rules>().isRugComplete = true;
        }

        if ((shampoo.GetComponent<ObjectController>().currentState == ObjectController.ObjectState.Clawed) && (rules.GetComponent<Rules>().win == false))
        {
            rules.GetComponent<Rules>().isShampooComplete = true;
        }

        if ((toiletWater.GetComponent<ObjectController>().currentState == ObjectController.ObjectState.Clawed) && (rules.GetComponent<Rules>().win == false))
        {
            rules.GetComponent<Rules>().isToiletComplete = true;
        }

        foreach (GameObject towel in towels)
        {
            if (towel.GetComponent<ObjectController>().currentState == ObjectController.ObjectState.Clawed)
            {
                TowelsClawed(1);
            }

            if ((clawedTowels >= towels.Length) && (rules.GetComponent<Rules>().win == false))
            {
                rules.GetComponent<Rules>().isTowelsComplete = true;
            }
        }
        clawedTowels = 0;

        if (rules.GetComponent<Rules>().win)
        {
            rules.GetComponent<Rules>().isToothbrushComplete = false;
            rules.GetComponent<Rules>().isRugComplete = false;
            rules.GetComponent<Rules>().isShampooComplete = false;
            rules.GetComponent<Rules>().isToiletComplete = false;
            rules.GetComponent<Rules>().isTowelsComplete = false;
            rules.GetComponent<Rules>().isRugPoopComplete = false;
        }

    }

    public void TowelsClawed(int clawed)
    {
        clawedTowels = clawedTowels + clawed;
    }

    public void TowelsNotClawed(int clawed)
    {
        clawedTowels -= clawed;
    }
}
