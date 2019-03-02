using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerFunctions))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    private float cameraSensitivity = 3f;
    private bool isGrounded;
    private bool fire = true;
    private bool fireMissile = true;
    public bool ballForm = false;

    public int hp = 99;
    public int missiles = 5;
    public int maxCapHp = 99;
    public int maxMissiles = 5;

    #region
    public bool electricBeam = false;
    public bool iceBeam = false;
    public bool fireBeam = false;
    public bool higherJump = false;
    public bool missilePickedUp = false;
    public bool morphBall = false;
    public bool gravtiySuit = false;
    public bool tempSuit = false;
    public bool light = false;
    #endregion

    public int currentBeam = 0;
    public GameObject body;
    public GameObject otherCam;
    public GameObject flashLight;
    private PlayerFunctions pf;
    private Rigidbody rb;

    void Start()
    {
        pf = GetComponent<PlayerFunctions>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("LeftStickX");
        float moveZ = Input.GetAxis("LeftStickY");

        //Movement
        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * -moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical) * playerSpeed;

        //calls function from PlayerFunctions script to Move
        pf.Move(velocity);

        
        //Camera Movement
        float rotateX = Input.GetAxis("RightStickY");
        Vector3 rotation = new Vector3(0f, rotateX, 0f) * cameraSensitivity;

        pf.Rotate(rotation);

        if (!ballForm)
        {
            float rotateY = Input.GetAxis("RightStickX");
            Vector3 cameraRotation = new Vector3(rotateY, 0f, 0f) * cameraSensitivity;

            pf.RotateCamera(cameraRotation);
        }

        //Jump
        if (Input.GetButtonDown("AButton") && isGrounded)
        {
            isGrounded = false;
            pf.Jump();

            if (Input.GetButtonDown("AButton") && higherJump)
            {
                pf.Jump();
            }
        }
        
        //Ball Form
        if (Input.GetButtonDown("XButton") && !ballForm && morphBall)
        {
            ballForm = true;
            body.SetActive(false);
            otherCam.SetActive(true);
        }

        else if (Input.GetButtonDown("XButton") && ballForm && isGrounded && morphBall)
        {
            ballForm = false;
            gameObject.transform.Translate(0, 1, 0);
            body.SetActive(true);
            otherCam.SetActive(false);
        }

        //Flash Light
        if (Input.GetButtonDown("YButton") && !ballForm && !light)
        {
            flashLight.SetActive(true);
            light = true;
        }

        else if (Input.GetButtonDown("YButton") && !ballForm && light)
        {
            flashLight.SetActive(false);
            light = false;
        }

        // Beam Selections
        if (Input.GetAxis("UpandDownDPad") == 1 && !ballForm)
        {
            currentBeam = 0;
        }

        if (Input.GetAxis("UpandDownDPad") == -1 && iceBeam && !ballForm)
        {
            currentBeam = 2;
        }

        if (Input.GetAxis("LeftandRightDPad") == 1 && fireBeam && !ballForm)
        {
            currentBeam = 1;
        }

        if (Input.GetAxis("LeftandRightDPad") == -1 && electricBeam && !ballForm)
        {
            currentBeam = 3;
        }

        //Firing Modes
        if (Input.GetAxis("RightTrigger") >= 0.8 && fire && !ballForm)
        {
            fire = false;
            pf.Fire(currentBeam);
        }

        else if (Input.GetAxis("RightTrigger") <= 0.3 && !fire && !ballForm)
        {
            fire = true;
        }

        if (Input.GetAxis("LeftTrigger") == 1 && missilePickedUp && fireMissile && !ballForm && missiles > 0)
        {
            Vector3 jerk=new Vector3(0,0,1);
            missiles--;
            rb.AddForce(jerk, ForceMode.Impulse);
            fireMissile = false;
            pf.FireMissile();
        }

        else if (Input.GetAxis("LeftTrigger") == 0 && missilePickedUp && !fireMissile && !ballForm )
        {
            fireMissile = true;
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
