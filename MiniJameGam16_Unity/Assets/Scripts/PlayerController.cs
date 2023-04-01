using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum AbilitiesState { Empty, Claws, Wee, Business, Tape };
    [SerializeField]
    private AbilitiesState currentAbility;
    [SerializeField]
    private int tapeAmmo = 0;

    public LayerMask moveableLayerMask;
    public LayerMask interactableLayerMask;

    public float forwardRayDistance = 7.5f;
    public float forwardRayHeight = 0.0f;

    RaycastHit hitForwardData;

    Vector3 forward;

    Quaternion forwardAngle;

    Ray rayForward;

    Vector3 hitPoint;

    public GameObject objectForward;
    [SerializeField]
    private bool objectMoveInRange = false;
    private bool objectInteractInRange = false;

    public GameObject weeSpawn;
    public GameObject businessSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetupRays();
        UpdateStateMachine();

        if (Input.GetKeyDown("0"))
        {
            ChangeAbility(AbilitiesState.Empty);
        }
        if (Input.GetKeyDown("1"))
        {
            ChangeAbility(AbilitiesState.Claws);
        }
        if (Input.GetKeyDown("2"))
        {
            ChangeAbility(AbilitiesState.Wee);
        }
        if (Input.GetKeyDown("3"))
        {
            ChangeAbility(AbilitiesState.Business);
        }
        if (Input.GetKeyDown("4"))
        {
            ChangeAbility(AbilitiesState.Tape);
        }
    }

    void SetupRays()
    {
        //Forward ray setup
        forwardAngle = Quaternion.AngleAxis(0.0f, new Vector3(0, -1, 0));
        forward = forwardAngle * (transform.forward + new Vector3(0, forwardRayHeight, 0));
        rayForward = new Ray(transform.position, forward);

        Debug.DrawRay(transform.position, forward * forwardRayDistance, Color.white);

        if (Physics.Raycast(rayForward, out hitForwardData, forwardRayDistance, moveableLayerMask))
        {
            objectMoveInRange = true;
            objectForward = hitForwardData.collider.gameObject;
            hitPoint = hitForwardData.point;
        }
        else
        {
            objectMoveInRange = false;
        }

        if (Physics.Raycast(rayForward, out hitForwardData, forwardRayDistance, interactableLayerMask))
        {
            objectInteractInRange = true;
            objectForward = hitForwardData.collider.gameObject;
            hitPoint = hitForwardData.point;
        }
        else
        {
            objectInteractInRange = false;
        }

        Debug.DrawRay(transform.position, forward * hitForwardData.distance, Color.yellow);
    }

    void UpdateStateMachine()
    {
        switch (currentAbility)
        {
            case AbilitiesState.Empty:

                break;

            case AbilitiesState.Claws:
                if (Input.GetButton("Fire1"))
                {
                    if ((objectMoveInRange) || (objectInteractInRange))
                    {
                        objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Clawed;
                    }
                }
                break;

            case AbilitiesState.Wee:
                if (Input.GetButton("Fire1"))
                {
                    if ((objectMoveInRange) || (objectInteractInRange))
                    {
                        objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Wet;
                        Instantiate(weeSpawn, hitPoint + new Vector3(0, 0.01f, 0), Quaternion.identity);

                    }
                }
                break;

            case AbilitiesState.Business:
                if (Input.GetButton("Fire1"))
                {
                    if (objectInteractInRange)
                    {
                        objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Duked;
                    }
                }
                break;
            case AbilitiesState.Tape:
                if ((Input.GetButton("Fire1")) && (tapeAmmo > 0))
                {
                    if ((objectMoveInRange) || (objectInteractInRange))
                    {
                        objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Taped;
                    }
                    tapeAmmo -= 1;
                }
                break;

        }
    }

    public void AddTapeAmmo(int ammo)
    {
        tapeAmmo = tapeAmmo + ammo;
    }

    public void ChangeAbility(AbilitiesState state)
    {
        currentAbility = state;
    }

}
