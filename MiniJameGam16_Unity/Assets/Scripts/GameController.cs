using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Material wetMaterial;
    public Material dukedMaterial;
    public Material clawedMaterial;
    public Material tapedMaterial;

    [SerializeField]
    private GameObject[] interactables;

    // Start is called before the first frame update
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject interactObject in interactables)
        {
            interactObject.GetComponent<ObjectController>().wetMaterial = wetMaterial;
            interactObject.GetComponent<ObjectController>().dukedMaterial = dukedMaterial;
            interactObject.GetComponent<ObjectController>().clawedMaterial = clawedMaterial;
            interactObject.GetComponent<ObjectController>().tapedMaterial = tapedMaterial;
        }


    }
}
