using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeamUpgradeScript : MonoBehaviour
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
            pc.iceBeam = true;
            pc.upgrades++;
            Destroy(this.gameObject);
        }
    }
}
