using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTank : MonoBehaviour
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
            if (pc.missilePickedUp)
            {
                pc.maxMissiles += 5;
                pc.missiles = pc.maxMissiles;
            }

            else
            {
                pc.missilePickedUp = true;
            }

            Destroy(this.gameObject);
        }
    }
}
