using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Animator winAnimator;
    public Animator loseAnimator;
    public GameObject youWin;
    public GameObject youLose;

    // Start is called before the first frame update
    void Start()
    {
        youWin.SetActive(false);
        youLose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //remove this later, linked victory anim to appear on button press for testing purposes
        if (Input.GetKeyDown(KeyCode.R))
        {
            Winner();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Loser();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void Winner()
    {
        PauseGame();
        youWin.SetActive(true);
        winAnimator.SetTrigger("Victory");
    }

    void Loser()
    {
        PauseGame();
        youLose.SetActive(true);
        loseAnimator.SetTrigger("Defeat");
    }
}
