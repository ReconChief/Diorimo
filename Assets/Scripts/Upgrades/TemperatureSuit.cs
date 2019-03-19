using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSuit : MonoBehaviour
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
            pc.tempSuit = true;

            Destroy(this.gameObject);
        }
    }
}
