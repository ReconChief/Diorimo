using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMainRoom : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pc.transformed)
            {
                pc.playerSpeed = 4.5f;

                pc.transformed = false;



                pc.body.SetActive(true);
                pc.playerModel.SetActive(true);

                pc.otherCam.SetActive(false);
                pc.transformationForest.SetActive(false);
                pc.transformationLava.SetActive(false);
                pc.transformationWater.SetActive(false);
            }
            pc.transformation = 0;
        }
    }
}
