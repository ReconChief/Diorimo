using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerFunctions : MonoBehaviour
{
    [SerializeField]
    private Camera playerCam;

    public GameObject player;
    public PlayerController pc;

    public GameObject missile;
    public GameObject[] beamObjects;
    public Transform beamSpawn;

    private Vector3 velocity = Vector3.zero;
    public Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    public Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    public float jumpForce = 2.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void Rotate(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    public void RotateCamera(Vector3 cameraRotation)
    {
        this.cameraRotation = cameraRotation;
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero && !pc.hardened)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (playerCam != null)
        {
            playerCam.transform.Rotate(cameraRotation);
        }
    }

    public void Jump()
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);           
    }

    public void Fire(int currentBeam)
    {
        GameObject bullet = (GameObject)Instantiate(beamObjects[currentBeam], beamSpawn.position, beamSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20f;

            Destroy(bullet, 1);
        
    }

    public void FireMissile()
    {
        GameObject missileShot = (GameObject)Instantiate(missile, beamSpawn.position, beamSpawn.rotation);

        missileShot.GetComponent<Rigidbody>().velocity = missileShot.transform.forward * 20f;

        Destroy(missileShot, 1);
    }
}
