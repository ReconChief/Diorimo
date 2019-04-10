using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float xAxisClamp;

    public GameObject player;
    public PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.ballForm && !pc.transformed && !pc.paused)
        {
            CameraRotation();
        }
    }

    public void CameraRotation()
    {
        float stickX = Input.GetAxis("RightStickY") * 3.0f;
        float stickY = -Input.GetAxis("RightStickX") * 3.0f;

        xAxisClamp += stickY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            stickY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }

        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            stickY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate((Vector3.left * stickY));
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eularRotation = transform.eulerAngles;
        eularRotation.x = value;
        transform.eulerAngles = eularRotation;
    }
}
