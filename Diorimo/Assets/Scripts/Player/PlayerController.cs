using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerFunctions))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    private float cameraSensitivity = 3f;
    private float xAxisClamp;
    private bool isGrounded;
    private bool fire = true;
    private bool fireMissile = true;
    public bool ballForm = false;

    public int transformation = 1;
    public bool transformed= false;
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
    public bool gravitySuit = false;
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

    //Animation shit
    private Animator anim;
    public bool walking=false;
    public bool pressed=false;
    public bool released=false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        pf = GetComponent<PlayerFunctions>();
        rb = GetComponent<Rigidbody>();

        xAxisClamp = 0.0f;
    }

    void Update()
    {
        //More Animator shit
        anim.SetBool("PogoActive", transformation == 2&&transformed);
        //anim.SetBool("IsMoving", walking);
        
            
        float moveX = Input.GetAxis("LeftStickX");
        float moveZ = Input.GetAxis("LeftStickY");

        //Movement
        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * -moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical) * playerSpeed;

        //pogo movement

        if (velocity != Vector3.zero && isGrounded)
            walking = true;
        else
            walking = false;

        //calls function from PlayerFunctions script to Move
        pf.Move(velocity);
        
        //Camera Movement
        float rotateX = Input.GetAxis("RightStickY");
        Vector3 rotation = new Vector3(0f, rotateX, 0f) * cameraSensitivity;

        pf.Rotate(rotation);

        //Jump
        if (Input.GetButtonDown("AButton") && isGrounded)
        {
            if (transformed)
            {
                pressed = true;
            }

            else
            {
                isGrounded = false;
                pf.Jump();

                if (Input.GetButtonDown("AButton") && higherJump)
                {
                    pf.Jump();
                }
            }
        }
        
        //Ball Form
        if (Input.GetButtonDown("XButton") && !ballForm && morphBall)
        {
            isGrounded = false;
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
            hardened = false;
            pf.Fire(currentBeam);
            Vector3 jerk = new Vector3(0, 0, -1);
            
            rb.AddForce(jerk, ForceMode.Impulse);
        }

        else if (Input.GetAxis("RightTrigger") <= 0.3 && !fire && !ballForm && !transformed)
        {
            fire = true;
            hardened = false;
        }

        //Charger Ability
        else if (Input.GetAxis("RightTrigger") >= 0.8 && isGrounded && !ballForm && transformed && transformation == 1)
        {
            gameObject.transform.Translate(0, 0, 1);
        }

        //Pogo Ability
        else if (Input.GetButtonUp("AButton") && isGrounded && !ballForm && transformed && transformation == 2)
        {
            
            released=true;
            pressed = false;
            isGrounded = false;
            pf.Jump();
            pf.Jump();

            if (higherJump)
            {
                pf.Jump();
                pf.Jump();
            }
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
            Vector3 jerk=new Vector3(0,0,-1);
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
            transformationLava.GetComponent<Animator>().enabled = true; 
           

        }

        //Transformation Code: Turtle
        else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 3)
        {
            playerSpeed = 2;
            transformed = true;
            body.SetActive(false);
            playerModel.SetActive(false);

            otherCam.SetActive(true);
            transformationWater.SetActive(true);
            transformationWater.GetComponent<Animator>().enabled = true;
        }

        //Transform Back
        else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && transformed)
        {
            playerSpeed = 4.5f;

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
