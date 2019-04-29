using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerFunctions))]
public class PlayerController : MonoBehaviour
{
    [Header("Variable stuff")]
    public float playerSpeed = 4.5f;
    private float cameraSensitivity = 3f;
    public bool isGrounded;
    private bool fire = true;
    private bool fireMissile = true;
    public bool ballForm = false;

    public int transformation = 1;
    public bool transformed = false;
    public bool hardened = false;

    public float hp = 99;
    public float missiles = 5;
    public float maxCapHp = 99;
    public float maxMissiles = 5;
    public int currentBeam = 0;
    [Space]
    #region
    [Header("Upgrades")]
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
    [Space]
    [Header("Cameras")]
    public GameObject Cam2;
    public GameObject body;
    public GameObject otherCam;
    [Space]
    #region
    [Header("Transfomation GameObjects")]
    public GameObject playerModel;
    public GameObject transformationForest;
    public GameObject transformationLava;
    public GameObject transformationWater;
    #endregion
    [Space]
    #region
    [Header("Sound Effects")]
    public AudioSource regularBeamSFX;
    public AudioSource electricBeamSFX;
    public AudioSource fireBeamSFX;
    public AudioSource waterBeamSFX;
    public AudioSource missileAttackSFX;
    #endregion
    [Space]
    public GameObject flashLight;
    public GameObject bs;
    public GameObject ds;
    public GameObject s;
    private PlayerFunctions pf;
    public Rigidbody rb;
    [Space]

    private Animator anim;
    [Header("Animation stuff")]
    public bool walking = false;
    public bool pressed = false;
    public bool released = false;
    public bool charging = false;
    [Space]
    [Header("PlayerUI")]
    public GameObject playerUI;
    public GameObject reticle;
    public GameObject console;
    public GameObject terminal;
    public GameObject Loading;
    public bool consoleInUse;
    private bool consoleUsable;
    private int timer;
    //PauseScreen
    public bool paused = false;
    public bool quit = false;
    public GameObject pauseScreen;
    public GameObject otherScreen;
    public GameObject other2Screen;
    [Space]
    //EventSystem
    public EventSystem eventSystem;
    public GameObject FirstButtonPaused;
    
    //Listen man, sometimes niggas need to know if they dead or nah
    public bool isDead = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        pf = GetComponent<PlayerFunctions>();
        rb = GetComponent<Rigidbody>();

        eventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {

        if (paused)
        {
            Time.timeScale = 0;
            playerUI.SetActive(false);

            if (!quit)
            {
                pauseScreen.SetActive(true);
            }

            if (Input.GetButtonDown("StartButton"))
            {
                paused = false;
                quit = false;
                pauseScreen.SetActive(false);
                otherScreen.SetActive(false);
                other2Screen.SetActive(false);
                playerUI.SetActive(true);
            }
        }
        else if (consoleInUse)
        {
            Debug.Log("Dafuq");
            timer--;
            Time.timeScale = 0;
            transform.position = bs.transform.position;
            transform.rotation = Quaternion.LookRotation(s.transform.position-transform.position);
            if (timer > 0)
            {

                Loading.SetActive(true);
            }
            if (timer == 0) {
                terminal.SetActive(true);
            }
            if (timer <= 0)
            {
                Loading.SetActive(false);
            }

        }
        else
        {
            if (!isDead)
            {
                Time.timeScale = 1;
            }

            //More Animator shit
            anim.SetBool("PogoActive", transformation == 2 && transformed);
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

            /*Ball Form
            if (Input.GetButtonDown("XButton") && !ballForm && morphBall && !transformed)
            {
                isGrounded = false;
                ballForm = true;
                body.SetActive(false);
                otherCam.SetActive(true);
            }

            else if (Input.GetButtonDown("XButton") && ballForm && isGrounded && morphBall && !transformed)
            {
                ballForm = false;
                gameObject.transform.Translate(0, 1, 0);
                body.SetActive(true);
                otherCam.SetActive(false);
            }
            */

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

                if (currentBeam == 0)
                {

                }

                if (currentBeam == 1)
                {
                    fireBeamSFX.Play();
                }

                if (currentBeam == 2)
                {
                    waterBeamSFX.Play();
                }

                if (currentBeam == 3)
                {
                    electricBeamSFX.Play();
                }

                pf.Fire(currentBeam);

            }

            else if (Input.GetAxis("RightTrigger") <= 0.3 && !fire && !ballForm && !transformed)
            {
                fire = true;
                hardened = false;
            }

            /*
            //Charger Ability
            else if (Input.GetAxis("RightTrigger") >= 0.8 && isGrounded && !ballForm && transformed && transformation == 5)
            {
                playerSpeed = 8;
                charging = true;

            }
            else if (Input.GetAxis("RightTrigger") <= 0.8 && isGrounded && !ballForm && transformed && transformation == 5)
            {
                charging = false;
            }
            */

            //Pogo Ability
            else if (Input.GetButtonUp("AButton") && isGrounded && !ballForm && transformed && transformation == 2)
            {
                released = true;
                pressed = false;
                isGrounded = false;
                pf.Jump();
                pf.Jump();

                if (higherJump)
                {
                    pf.Jump();
                    //pf.Jump();
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
                Vector3 jerk = new Vector3(0, 0, -1);
                missiles--;
                rb.AddForce(jerk, ForceMode.Impulse);
                fireMissile = false;
                pf.FireMissile();
                missileAttackSFX.Play();
            }

            else if (Input.GetAxis("LeftTrigger") == 0 && missilePickedUp && !fireMissile && !ballForm && !transformed)
            {
                fireMissile = true;
            }

            //Transfomation Modes

            //Transformation Code: Charger
            /*
            if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 1)
            {
                isGrounded = false;
                transformed = true;
                body.SetActive(false);
                playerModel.SetActive(false);
                reticle.SetActive(false);
                otherCam.SetActive(true);
                transformationForest.SetActive(true);
            }
            */

            //Transformation Code: Pogo
            else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 2)
            {
                isGrounded = false;
                transformed = true;
                body.SetActive(false);
                playerModel.SetActive(false);
                reticle.SetActive(false);
                otherCam.SetActive(true);
                transformationLava.SetActive(true);
                transformationLava.GetComponent<Animator>().enabled = true;


            }

            //Transformation Code: Turtle
            else if (Input.GetButtonDown("BButton") && isGrounded && !ballForm && !transformed && transformation == 3)
            {
                isGrounded = false;
                playerSpeed = 2;
                transformed = true;
                body.SetActive(false);
                playerModel.SetActive(false);
                reticle.SetActive(false);
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
                reticle.SetActive(true);
                otherCam.SetActive(false);
                transformationForest.SetActive(false);
                transformationLava.SetActive(false);
                transformationWater.SetActive(false);
            }

            if (Input.GetButtonDown("StartButton"))
            {
                paused = true;
                eventSystem.SetSelectedGameObject(FirstButtonPaused, null);
            }
            if (consoleUsable)
            {
                if (Input.GetButtonDown("XButton"))
                {
                    timer = 150;
                    consoleInUse = true;

                    playerUI.SetActive(false);
                    console.SetActive(false);
                    
                    if (timer > 0)
                    {
                       
                        Loading.SetActive(true);
                    }
                    
                    if (timer <= 0) {
                        Loading.SetActive(false);
                        
                    }
                }
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Console"))
        {
            consoleUsable = true;
            console.SetActive(true);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Console"))
        {

            console.SetActive(false);
        }

    }
}
