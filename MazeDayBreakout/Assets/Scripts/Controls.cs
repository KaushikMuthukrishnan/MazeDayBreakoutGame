using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;

    float Rotation = 0f;
    public float rotateSpeed = 75f;
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {


        float MouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        Player.transform.Rotate(Vector3.up * MouseX);
        Rotation -= MouseY;
        Rotation = Mathf.Clamp(Rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f);
    }
}
