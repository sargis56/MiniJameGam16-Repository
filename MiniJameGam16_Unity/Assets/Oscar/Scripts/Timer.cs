using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public EndGame endGame;
    public Slider slider;
    public float countdownTime = 300f;
    private float currentTime; 

    void Start()
    {
        currentTime = slider.value = 0;
        slider.maxValue = countdownTime;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        slider.value = currentTime;

        if (currentTime >= countdownTime )
        {
            //have the YouLose screen pop up here
            currentTime = 299.0f;
            endGame.Loser();
        }
    }
}
