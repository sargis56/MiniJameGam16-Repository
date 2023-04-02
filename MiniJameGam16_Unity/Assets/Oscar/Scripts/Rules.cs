using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Rules : MonoBehaviour
{
    public bool debug;
    public bool win = false;

    public EndGame endGame;

    public Animator enlargeRules;
    public AnimationClip RulesEnlarge;
    public AnimationClip RulesNormal;

    public GameObject bathroom;
    //public GameObject livingroom;
    public TextMeshProUGUI toothbrush;
    public TextMeshProUGUI toilet;
    public TextMeshProUGUI towels;
    public TextMeshProUGUI rug;
    public TextMeshProUGUI rugPoop;
    public TextMeshProUGUI shampoo;

    public bool isToothbrushComplete = false;
    public bool isToiletComplete = false;
    public bool isTowelsComplete = false;
    public bool isRugComplete = false;
    public bool isRugPoopComplete = false;
    public bool isShampooComplete = false;

    private bool isEnlarged = false;

    public Color black = Color.black;
    public Color red = Color.red;

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
        if (Input.GetKeyDown(KeyCode.F) && (debug))
        {
            isToothbrushComplete = !isToothbrushComplete;
            toothbrush.color = isToothbrushComplete ? red : black;
            toothbrush.fontStyle = isToothbrushComplete ? toothbrush.fontStyle = FontStyles.Strikethrough : toothbrush.fontStyle = FontStyles.Normal;
        }
        if (Input.GetKeyDown(KeyCode.R) && (debug))
        {
            isRugComplete = !isRugComplete;
            rug.color = isRugComplete ? red : black;
            rug.fontStyle = isRugComplete ? rug.fontStyle = FontStyles.Strikethrough : rug.fontStyle = FontStyles.Normal;
        }
        if (Input.GetKeyDown(KeyCode.G) && (debug))
        {
            isShampooComplete = !isShampooComplete;
            shampoo.color = isShampooComplete ? red : black;
            shampoo.fontStyle = isShampooComplete ? shampoo.fontStyle = FontStyles.Strikethrough : shampoo.fontStyle = FontStyles.Normal;
        }
        if (Input.GetKeyDown(KeyCode.H) && (debug))
        {
            isToiletComplete = !isToiletComplete;
            toilet.color = isToiletComplete ? red : black;
            toilet.fontStyle = isToiletComplete ? toilet.fontStyle = FontStyles.Strikethrough : toilet.fontStyle = FontStyles.Normal;
        }
        if (Input.GetKeyDown(KeyCode.J) && (debug))
        {
            isTowelsComplete = !isTowelsComplete;
            towels.color = isTowelsComplete ? red : black;
            towels.fontStyle = isTowelsComplete ? towels.fontStyle = FontStyles.Strikethrough : towels.fontStyle = FontStyles.Normal;
        }
        //UPDATE HERE SO IF ALL RULES ARE COMPLETE, THEN GAME WIN, call it from the EndGame script function Winner()
        //as of time of writing, only have the 5 bathroom rules so will just hardcode it
        else if ((isToothbrushComplete & isRugComplete & isShampooComplete & isToiletComplete & isTowelsComplete) && (debug))
        {
            //setting one to false so it doesnt get stuck on loop trying to open up win window
            isToothbrushComplete = false;
            endGame.Winner();
        }

        if (isToothbrushComplete)
        {
            toothbrush.color = isToothbrushComplete ? red : black;
            toothbrush.fontStyle = isToothbrushComplete ? toothbrush.fontStyle = FontStyles.Strikethrough : toothbrush.fontStyle = FontStyles.Normal;
        }
        if (isRugPoopComplete)
        {
            rugPoop.color = isRugPoopComplete ? red : black;
            rugPoop.fontStyle = isRugPoopComplete ? rugPoop.fontStyle = FontStyles.Strikethrough : rugPoop.fontStyle = FontStyles.Normal;
        }
        if (isRugComplete)
        {
            rug.color = isRugComplete ? red : black;
            rug.fontStyle = isRugComplete ? rug.fontStyle = FontStyles.Strikethrough : rug.fontStyle = FontStyles.Normal;
        }
        if (isShampooComplete)
        {
            shampoo.color = isShampooComplete ? red : black;
            shampoo.fontStyle = isShampooComplete ? shampoo.fontStyle = FontStyles.Strikethrough : shampoo.fontStyle = FontStyles.Normal;
        }
        if (isTowelsComplete)
        {
            towels.color = isTowelsComplete ? red : black;
            towels.fontStyle = isTowelsComplete ? towels.fontStyle = FontStyles.Strikethrough : towels.fontStyle = FontStyles.Normal;
        }

        if (isToiletComplete)
        {
            toilet.color = isToiletComplete ? red : black;
            toilet.fontStyle = isToiletComplete ? toilet.fontStyle = FontStyles.Strikethrough : toilet.fontStyle = FontStyles.Normal;
        }

        if (isToothbrushComplete && isRugComplete && isShampooComplete && isToiletComplete && isTowelsComplete && isRugPoopComplete)
        {
            win = true;
            endGame.Winner();
        }

    }

    public void Lost()
    {
        endGame.Loser();
    }

}
