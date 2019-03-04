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

    public int transformation = 1;
    private bool transformed= false;
    public bool hardened = false;

    public int hp = 99;
    public int missiles = 5;
    public int maxCapHp = 99;
    public int maxMissiles = 5;

    #region
    //Upgrades
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

    //Transfomation GameObjects
    public GameObject playerModel;
    public GameObject transformationForest;
    public GameObject transformationLava;
    public GameObject transformationWater;

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

        if (!ballForm && !transformed)
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
        if (Input.GetButtonDown("YButton") && !ballForm && !light && !transformed)
        {
            flashLight.SetActive(true);
            light = true;
        }

        else if (Input.GetButtonDown("YButton") && !ballForm && light && !transformed)
        {
            flashLight.SetActive(false);
            light = false;
        }

        // Beam Selections
        if (Input.GetAxis("UpandDownDPad") == 1 && !ballForm && !transformed)
        {
            currentBeam = 0;
        }

        if (Input.GetAxis("UpandDownDPad") == -1 && iceBeam && !ballForm && !transformed)
        {
            currentBeam = 2;
        }

        if (Input.GetAxis("LeftandRightDPad") == 1 && fireBeam && !ballForm && !transformed)
        {
            currentBeam = 1;
        }

        if (Input.GetAxis("LeftandRightDPad") == -1 && electricBeam && !ballForm && !transformed)
        {
            currentBeam = 3;
        }

        //Firing Modes And Transformation Ability

        //Firing Beams
        if (Input.GetAxis("RightTrigger") >= 0.8 && fire && !ballForm && !transformed)
        {
            fire = false;
            pf.Fire(currentBeam);
        }

        else if (Input.GetAxis("RightTrigger") <= 0.3 && !fire && !ballForm && !transformed)
        {
            fire = true;
        }

        //Charger Ability
        else if (Input.GetAxis("RightTrigger") >= 0.8 && isGrounded && !ballForm && transformed && transformation == 1)
        {
            gameObject.transform.Translate(0, 0, 1);
        }

        //Pogo Ability
        else if (Input.GetAxis("RightTrigger") >= 0.8 && isGrounded && !ballForm && transformed && transformation == 2)
        {
            isGrounded = false;
            pf.Jump();
            pf.Jump();
            pf.Jump();
            pf.Jump();
        }

        //Turtle Ability
        else if (Input.GetAxis("RightTrigger") >= 0.8 && isGrounded && !ballForm && transformed && transformation == 3)
        {
            hardened = true;
        }

        else if (Input.GetAxis("RightTrigger") <= 0.8 && isGrounded && !ballForm && transformed && transformation == 3)
        {
            hardened = false;
        }

        //Firing Missile

        if (Input.GetAxis("LeftTrigger") == 1 && missilePickedUp && fireMissile && !ballForm && missiles > 0 && !transformed)
        {
            Vector3 jerk=new Vector3(0,0,1);
            missiles--;
            rb.AddForce(jerk, ForceMode.Impulse);
            fireMissile = false;
            pf.FireMissile();
        }

        else if (Input.GetAxis("LeftTrigger") == 0 && missilePickedUp && !fireMissile && !ballForm && !transformed)
        {
            fireMissile = true;
        }


        //Transfomation Modes

        //Transformation Code: Charger
        if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 1)
        {
            transformed = true;
            body.SetActive(false);
            playerModel.SetActive(false);

            otherCam.SetActive(true);
            transformationForest.SetActive(true);
        }

        //Transformation Code: Pogo
        else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 2)
        {
            transformed = true;
            body.SetActive(false);
            playerModel.SetActive(false);

            otherCam.SetActive(true);
            transformationLava.SetActive(true);
        }

        //Transformation Code: Turtle
        else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 3)
        {
            transformed = true;
            body.SetActive(false);
            playerModel.SetActive(false);

            otherCam.SetActive(true);
            transformationWater.SetActive(true);
        }

        //Transform Back
        else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && transformed)
        {
            transformed = false;

            gameObject.transform.Translate(0, 1, 0);

            body.SetActive(true);
            playerModel.SetActive(true);

            otherCam.SetActive(false);
            transformationForest.SetActive(false);
            transformationLava.SetActive(false);
            transformationWater.SetActive(false);
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
