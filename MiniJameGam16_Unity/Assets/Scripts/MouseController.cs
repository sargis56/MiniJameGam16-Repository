using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sens = 1000.0f;
    public Transform body;
    Vector3 rot = Vector3.zero;
    Vector3 mouse = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouse.x = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        mouse.y = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        rot.x -= mouse.y;
        rot.x = Mathf.Clamp(rot.x, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(rot);

        body.Rotate(Vector3.up * mouse.x);
    }

}
