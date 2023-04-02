using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Animator winAnimator;
    public Animator loseAnimator;
    public GameObject youWin;
    public GameObject youLose;

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Winner()
    {
        PauseGame();
        youWin.SetActive(true);
        winAnimator.SetTrigger("Victory");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Loser()
    {
        PauseGame();
        youLose.SetActive(true);
        loseAnimator.SetTrigger("Defeat");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
