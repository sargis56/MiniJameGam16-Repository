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

    public UI_Abilities uiAbilities;

    public LayerMask moveableLayerMask;
    public LayerMask interactableLayerMask;
    public LayerMask groundLayerMask;
    public LayerMask weeLayerMask;
    public LayerMask dukeLayerMask;

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
    private bool groundInRange = false;

    public GameObject weeSpawn;
    public GameObject businessSpawn;

    [SerializeField]
    private float clawForce = 2.5f;

    public MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        currentAbility = AbilitiesState.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        SetupRays();
        UpdateStateMachine();

        if (tapeAmmo > 0)
        {
            uiAbilities.GetComponent<UI_Abilities>().isTapeCollected = true;
        }
        else
        {
            uiAbilities.GetComponent<UI_Abilities>().isTapeCollected = false;
        }

        if (Input.GetKeyDown("0"))
        {
            ChangeAbility(AbilitiesState.Empty);
        }
        if (Input.GetKeyDown("1"))
        {
            if (currentAbility == AbilitiesState.Claws)
            {
                ChangeAbility(AbilitiesState.Empty);
            }
            else
            {
                ChangeAbility(AbilitiesState.Claws);
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (currentAbility == AbilitiesState.Wee)
            {
                ChangeAbility(AbilitiesState.Empty);
            }
            else
            {
                ChangeAbility(AbilitiesState.Wee);
            }
        }
        if (Input.GetKeyDown("4"))
        {
            if (currentAbility == AbilitiesState.Business)
            {
                ChangeAbility(AbilitiesState.Empty);
            }
            else
            {
                ChangeAbility(AbilitiesState.Business);
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (currentAbility == AbilitiesState.Tape)
            {
                ChangeAbility(AbilitiesState.Empty);
            }
            else
            {
                ChangeAbility(AbilitiesState.Tape);
            }
        }
    }

    void SetupRays()
    {
        //Forward ray setup
        forwardAngle = Quaternion.AngleAxis(0.0f, new Vector3(0, -1, 0));
        forward = forwardAngle * (transform.forward + new Vector3(0, forwardRayHeight, 0));
        rayForward = new Ray(transform.position, forward);

        Debug.DrawRay(transform.position, forward * forwardRayDistance, Color.white);

        if (Physics.Raycast(rayForward, out hitForwardData, forwardRayDistance, groundLayerMask))
        {
            groundInRange = true;
            objectForward = hitForwardData.collider.gameObject;
            hitPoint = hitForwardData.point;
        }
        else
        {
            groundInRange = false;
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

        if (Physics.Raycast(rayForward, out hitForwardData, forwardRayDistance, weeLayerMask))
        {
            objectMoveInRange = false;
            objectForward = hitForwardData.collider.gameObject;
            objectInteractInRange = false;
        }

        if (Physics.Raycast(rayForward, out hitForwardData, forwardRayDistance, dukeLayerMask))
        {
            objectMoveInRange = false;
            objectForward = hitForwardData.collider.gameObject;
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
                if (Input.GetButtonDown("Fire1"))
                {
                    if (objectMoveInRange)
                    {
                        objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Clawed;

                        Vector3 forceDir = objectForward.gameObject.transform.position - transform.position;
                        forceDir.y = 0;
                        forceDir.Normalize();

                        objectForward.GetComponent<Collider>().attachedRigidbody.AddForceAtPosition(forceDir * clawForce, transform.position, ForceMode.Impulse);
                    }
                }
                break;

            case AbilitiesState.Wee:
                if (Input.GetButtonDown("Fire1"))
                {
                    if ((groundInRange) || (objectInteractInRange))
                    {
                        if (objectForward.gameObject.layer != LayerMask.NameToLayer("Ground"))
                        {
                            objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Wet;
                        }
                        Instantiate(weeSpawn, hitPoint + new Vector3(0, -0.1f, 0), Quaternion.identity);
                    }
                }
                break;

            case AbilitiesState.Business:
                if (Input.GetButtonDown("Fire1"))
                {
                    if ((groundInRange) || (objectInteractInRange))
                    {
                        if (objectForward.gameObject.layer != LayerMask.NameToLayer("Ground"))
                        {
                            objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Duked;
                        }
                        Instantiate(businessSpawn, hitPoint + new Vector3(0, 0.1f, 0), Quaternion.Euler(Vector3.right * 90));
                    }
                }
                break;
            case AbilitiesState.Tape:
                if (Input.GetButtonDown("Fire1"))
                {
                    //if ((objectMoveInRange) || (objectInteractInRange))
                    //{
                    //    objectForward.GetComponent<ObjectController>().currentState = ObjectController.ObjectState.Taped;
                    //}

                    if (movementController.GetComponent<MovementController>().stickyCat == true)
                    {
                        movementController.GetComponent<MovementController>().StickyModeEnd();
                    }
                    else
                    {
                        if (tapeAmmo > 0)
                        {
                            movementController.GetComponent<MovementController>().stickyCat = true;
                            TakeTapeAmmo(1);
                        }
                    }
                }
                break;

        }
    }

    public void AddTapeAmmo(int ammo)
    {
        tapeAmmo = tapeAmmo + ammo;
    }

    public void TakeTapeAmmo(int ammo)
    {
        tapeAmmo -= ammo;
    }

    public void ChangeAbility(AbilitiesState state)
    {
        currentAbility = state;
    }

}
