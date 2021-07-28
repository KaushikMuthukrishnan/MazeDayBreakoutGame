using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controls : MonoBehaviour
{
    public Transform Player;
    float rotation = 0f;
    public float rotSensitivity = 3;
    //planning to have rotation sensitivity to be on a scale of 1-10
    //!I think this will be a good idea
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //There is a rare glitch where the character freezes upon loading, which is resolved when toggling on and off the CC
        //This code is meant to simulate that toggle to reduce the chance of this glitch
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
        float MouseX = Input.GetAxis("Mouse X") * rotSensitivity; //see above for rotSensitivity scale
        float MouseY = Input.GetAxis("Mouse Y") * rotSensitivity;
        Player.Rotate(0, MouseX, 0);
        rotation -= MouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
    }


}
