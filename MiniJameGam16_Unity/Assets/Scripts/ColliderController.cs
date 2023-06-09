using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private float initialMagntiude = 5;
    [SerializeField]
    private float sprintingMagntiude = 10;
    private float forceMagntiude;

    public MovementController movementController;
    public PlayerController playerController;
    public Rules rules;

    public LayerMask moveableLayerMask;
    public LayerMask interactableLayerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementController.GetComponent<MovementController>().sprinting)
        {
            forceMagntiude = initialMagntiude;
        }
        else
        {
            forceMagntiude = sprintingMagntiude;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if ((rigidbody != null) && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Moveable")))
        {
            Vector3 forceDir = hit.gameObject.transform.position - transform.position;
            forceDir.y = 0;
            forceDir.Normalize();

            rigidbody.AddForceAtPosition(forceDir * forceMagntiude, transform.position, ForceMode.Impulse);
        }

        if (hit.gameObject.tag == "Tape")
        {
            Destroy(hit.gameObject);
            playerController.GetComponent<PlayerController>().AddTapeAmmo(1);
        }

        if (hit.gameObject.tag == "Water")
        {
            rules.GetComponent<Rules>().Lost();
        }

    }
}
