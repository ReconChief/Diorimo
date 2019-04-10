using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBeamTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject electricBeamTutorial;

    private PlayerController pc;
    private ElectricBeamTrigger electricBeamTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        electricBeamTrigger = this.GetComponent<ElectricBeamTrigger>();
        electricBeamTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            electricBeamTrigger.enabled = true;
            electricBeamTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        electricBeamTutorial.SetActive(false);
        electricBeamTrigger.enabled = false;
    }
}
