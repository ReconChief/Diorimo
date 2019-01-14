using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {

        float moveY = Input.GetAxis("LeftStickY");
        float moveX = Input.GetAxis("LeftStickX");

        float rotateY = Input.GetAxis("RightStickY");
        float rotateX = Input.GetAxis("RightStickX");

        transform.Translate(moveX * .1f, 0, -moveY * .1f);

        if (playerCamera.transform.rotation != Quaternion.Euler(rotateX, 90f, 0f))
        {
            playerCamera.transform.Rotate(rotateX, rotateY, 0);
        }

        if (Input.GetButtonDown("LeftStickButton"))
        {
            Debug.Log("1");
        }

        if (Input.GetButtonDown("RightStickButton"))
        {
            Debug.Log("2");
        }

        if (Input.GetAxis("LeftTrigger") == 1)
        {
            Debug.Log("3");
        }

        if (Input.GetAxis("RightTrigger") == 1)
        {
            Debug.Log("4");
        }
    }
}
