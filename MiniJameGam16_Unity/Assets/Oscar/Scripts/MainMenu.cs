using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource soundEffect;
    public GameObject mainScreen;
    public GameObject audioScreen;
    public GameObject creditsScreen;

    private void Start()
    {
        mainScreen.SetActive(true);
        audioScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void StartGame(int sceneID)
    {
        soundEffect.Play();
        SceneManager.LoadScene(sceneID);
    }

    public void ReturnToMainMenuFromCredits()
    {
        soundEffect.Play();
        creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void ReturnToMainMenuFromAudio()
    {
        soundEffect.Play();
        audioScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void OpenCredits()
    {
        soundEffect.Play();
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void OpenAudio()
    {
        soundEffect.Play();
        mainScreen.SetActive(false);
        audioScreen.SetActive(true);
    }
}
