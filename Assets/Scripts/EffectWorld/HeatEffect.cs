using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatEffect : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;
    private HeatEffect heat;

    public AudioSource lavaSong;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        heat = this.GetComponent<HeatEffect>();
        heat.enabled = false;
    }

    void Update()
    {
        if (!pc.tempSuit)
        {
            pc.hp -= 1;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            heat.enabled = true;
            lavaSong.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        heat.enabled = false;
        lavaSong.Stop();
    }
}
