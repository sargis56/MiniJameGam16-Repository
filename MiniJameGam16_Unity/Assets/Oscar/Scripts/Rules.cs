using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Rules : MonoBehaviour
{
    public Animator enlargeRules;
    public AnimationClip RulesEnlarge;
    public AnimationClip RulesNormal;

    public GameObject bathroom;
    //public GameObject livingroom;
    public TextMeshProUGUI toothbrush;
    public TextMeshProUGUI toilet;
    public TextMeshProUGUI towels;
    public TextMeshProUGUI rug;
    public TextMeshProUGUI shampoo;

    private bool isComplete = false;
    private bool isEnlarged = false;

    private Color black = Color.black;
    private Color red = Color.red;

    void Start()
    {
        enlargeRules = GetComponent<Animator>();
    }

    void Update()
    {
        // ON RIGHT MOUSE CLICK, TOGGLE RULES ENLARGE ANIM
        if (Input.GetMouseButtonDown(1))

            if (!isEnlarged)
            {
                enlargeRules.SetTrigger("Enlarge");
                isEnlarged = true;
            }
            else
            {
                enlargeRules.SetTrigger("Normal");
                isEnlarged = false;
            }
    

        //UPDATE RULES DEPENDING ON ROOM YOU'RE IN
        //link a collision trigger for each room entry/exit to determine which room rules will display



        //UPDATE RULES TO STRIKETHROUGH+RED ON COMPLETE
        //link the collision here to make bool isComplete = true and update the rules text to strikethrough and color red
        //placeholder for now to a keydown for testing purposes, fix this later
        if (Input.GetKeyDown(KeyCode.F))
        {
            isComplete = !isComplete;
            toothbrush.color = isComplete ? red : black;
            toothbrush.fontStyle = isComplete ? toothbrush.fontStyle = FontStyles.Strikethrough : toothbrush.fontStyle = FontStyles.Normal;
        }

        //UPDATE HERE SO IF ALL RULES ARE COMPLETE, THEN GAME WIN
        //as of time of writing, only have the 5 bathroom rules so will just hardcode it
        if (toothbrush && toilet && towels && rug && shampoo == isComplete)
        {
            //pause game and make YouWin! visible here
        }
    }
}
