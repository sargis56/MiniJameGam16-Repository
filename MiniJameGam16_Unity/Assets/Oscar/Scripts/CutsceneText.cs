using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText : MonoBehaviour
{
    public TextMeshProUGUI cutsceneText;
    public string[] cutsceneDialogue;
    private int currentDialogueIndex = 0;

    private void Update()
    {
        //LMB or Spacebar to update text
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentDialogueIndex < cutsceneDialogue.Length)
            {
                cutsceneText.text = cutsceneDialogue[currentDialogueIndex];
                currentDialogueIndex++;
            }

            else
            {
                // SET THIS NUMBER TO WHATEVER THE PLAYABLE LEVEL SCENE INDEX IS, LOOK AT BUILD SETTINGS OPEN SCENES TO SEE
                Debug.Log("story dialogue over");
                SceneManager.LoadScene(2);
            }
        }
    }
}
