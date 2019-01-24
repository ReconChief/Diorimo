using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerFunctions))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;
    private float cameraSensitivity = 3f;
    private bool isGrounded;
    private bool fire = true;

    #region
    public bool electricBeam = false;
    public bool iceBeam = false;
    public bool fireBeam = false;
    public bool higherJump = false;
    #endregion

    public int currentBeam = 0;

    private PlayerFunctions pf;

    void Start()
    {
        pf = GetComponent<PlayerFunctions>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("LeftStickX");
        float moveZ = Input.GetAxis("LeftStickY");

        //Movement
        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * -moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * playerSpeed;

        //calls function from PlayerFunctions script to Move
        pf.Move(velocity);

        //Camera Movement
        float rotateX = Input.GetAxis("RightStickY");
        Vector3 rotation = new Vector3(0f, rotateX, 0f) * cameraSensitivity;

        pf.Rotate(rotation);

        float rotateY = Input.GetAxis("RightStickX");
        Vector3 cameraRotation = new Vector3(rotateY, 0f, 0f) * cameraSensitivity;

        pf.RotateCamera(cameraRotation);

        if (Input.GetButtonDown("AButton") && isGrounded)
        {
            isGrounded = false;
            pf.Jump();

            if (Input.GetButtonDown("AButton") && higherJump)
            {
                pf.Jump();
            }
        }

        if (Input.GetAxis("UpandDownDPad") == 1)
        {
            currentBeam = 0;
        }

        if (Input.GetAxis("UpandDownDPad") == -1 && iceBeam)
        {
            currentBeam = 2;
        }

        if (Input.GetAxis("LeftandRightDPad") == 1 && fireBeam)
        {
            currentBeam = 1;
        }

        if (Input.GetAxis("LeftandRightDPad") == -1 && electricBeam)
        {
            currentBeam = 3;
        }

        if (Input.GetAxis("RightTrigger") >= 0.8 && fire)
        {
            fire = false;
            pf.Fire(currentBeam);
        }

        if (Input.GetAxis("RightTrigger") <= 0.3 && !fire)
        {
            fire = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
