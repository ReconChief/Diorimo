using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStatement : MonoBehaviour
{
    private GameObject player;
    public GameObject EnergyTankTutorial;

    private PlayerController pc;
    private MissionStatement missionStatement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        missionStatement = this.GetComponent<MissionStatement>();
        missionStatement.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            missionStatement.enabled = true;
            EnergyTankTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        EnergyTankTutorial.SetActive(false);
        missionStatement.enabled = false;
    }
}
