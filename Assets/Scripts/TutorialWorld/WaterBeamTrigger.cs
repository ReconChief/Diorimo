using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBeamTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject waterBeamTutorial;

    private PlayerController pc;
    private WaterBeamTrigger waterBeamTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        waterBeamTrigger = this.GetComponent<WaterBeamTrigger>();
        waterBeamTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            waterBeamTrigger.enabled = true;
            waterBeamTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        waterBeamTutorial.SetActive(false);
        waterBeamTrigger.enabled = false;
    }
}
