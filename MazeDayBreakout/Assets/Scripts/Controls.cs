using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controls : MonoBehaviour
{
    public Transform Player;
    float Rotation = 0f;
    public float rotateSpeed = 75f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnTriggerEnter(Collider other)
    {
        Movement.Frozen = false;
        // Debug.Log("TRIGGERED!");
    }
    void Update()
    {
        if (Movement.Frozen)
            return;
        float MouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        Player.Rotate(0, MouseX, 0);
        Rotation -= MouseY;
        Rotation = Mathf.Clamp(Rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f);
    }


}
