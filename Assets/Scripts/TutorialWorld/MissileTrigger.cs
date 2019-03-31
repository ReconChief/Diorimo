using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject missileTutorial;

    private PlayerController pc;
    private MissileTrigger missileTrigger;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        missileTrigger = this.GetComponent<MissileTrigger>();
        missileTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            missileTrigger.enabled = true;
            missileTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        missileTutorial.SetActive(false);
        missileTrigger.enabled = false;
    }
}
