using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileRegen : MonoBehaviour
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
            if (pc.missiles < pc.maxMissiles)
            {
                pc.missiles += 2;

                if (pc.missiles > pc.maxMissiles)
                {
                    pc.missiles = pc.maxMissiles;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
