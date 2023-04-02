using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public Animator animator;
    public GameObject youWin;

    // Start is called before the first frame update
    void Start()
    {
        youWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //remove this later, linked victory anim to appear on button press for testing purposes
        if (Input.GetKeyDown(KeyCode.R))
        {
            Winner();
        }

    }

    void Winner()
    {
        youWin.SetActive(true);
        animator.SetTrigger("Victory");
    }

    void OnClick()
    {

    }
}
