using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool debug;

    public bool grounded = false;

    public bool sprinting;

    public Vector3 vel = Vector3.zero;

    public float velRest = -2.0f;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float sprintSpeed = 10.0f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 1.0f;

    public CharacterController charController;
    public MouseController mouseController;

    public Transform groundCheck;

    [SerializeField]
    private float distanceFromGround = 0.4f;

    public LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        grounded = Physics.CheckSphere(groundCheck.position, distanceFromGround, groundLayerMask);

        if (grounded && vel.y < 0.0f)
        {
            if (debug)
            {
                print("Debug - " + this.gameObject.GetComponent<MonoBehaviour>() + ": Grounded");
            }
            vel.y = velRest;
        }

        if (Input.GetButton("Sprint"))
        {
            if (debug)
            {
                print("Debug - " + this.gameObject.GetComponent<MonoBehaviour>() + ": Sprint");
            }
            sprinting = true;
            Move(moveHorizontal, moveVertical, sprintSpeed);
        }
        else
        {
            sprinting = false;
            Move(moveHorizontal, moveVertical, speed);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump(jumpHeight);
        }

        vel.y += gravity * Time.deltaTime;
        charController.Move(vel * Time.deltaTime);
    }

    public void Move(float horizontalMovement, float verticalMovement, float moveSpeed)
    {
        if (debug)
        {
            print("Debug - " + this.gameObject.GetComponent<MonoBehaviour>() + ": Move");
        }
        charController.Move((transform.right * horizontalMovement + transform.forward * verticalMovement) * moveSpeed * Time.deltaTime);
    }

    public void Jump(float height_)
    {
        if (debug)
        {
            print("Debug - " + this.gameObject.GetComponent<MonoBehaviour>() + ": Jump");
        }

        vel.y = Mathf.Sqrt(height_ * -2.0f * gravity);
    }
}
