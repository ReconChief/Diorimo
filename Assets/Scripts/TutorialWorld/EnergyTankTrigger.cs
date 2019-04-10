using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTankTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject EnergyTankTutorial;

    private PlayerController pc;
    private EnergyTankTrigger energyTankTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        energyTankTrigger = this.GetComponent<EnergyTankTrigger>();
        energyTankTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            energyTankTrigger.enabled = true;
            EnergyTankTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        EnergyTankTutorial.SetActive(false);
        energyTankTrigger.enabled = false;
    }
}
