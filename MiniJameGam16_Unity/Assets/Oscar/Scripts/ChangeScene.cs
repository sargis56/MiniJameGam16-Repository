using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
