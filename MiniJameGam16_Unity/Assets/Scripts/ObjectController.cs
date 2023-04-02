using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public enum ObjectState { Normal, Clawed, Wet, Duked, Taped };
    public ObjectState currentState;

    private Material material_ORG;

    public Material wetMaterial;
    public Material dukedMaterial;
    public Material clawedMaterial;
    public Material tapedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        material_ORG = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateStateMachine();

    }

    void UpdateStateMachine()
    {
        switch (currentState)
        {
            case ObjectState.Normal:
                this.gameObject.GetComponent<MeshRenderer>().material = material_ORG;
                break;

            case ObjectState.Clawed:
                this.gameObject.GetComponent<MeshRenderer>().material = clawedMaterial;
                break;

            case ObjectState.Wet:
                //this.gameObject.GetComponent<MeshRenderer>().material = wetMaterial;
                break;

            case ObjectState.Duked:
                this.gameObject.GetComponent<MeshRenderer>().material = dukedMaterial;
                break;
            case ObjectState.Taped:
                this.gameObject.GetComponent<MeshRenderer>().material = tapedMaterial;
                break;
        }

    }
}
