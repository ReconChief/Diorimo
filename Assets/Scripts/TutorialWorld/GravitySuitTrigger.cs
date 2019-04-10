using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySuitTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject gravitySuitTutorial;

    private PlayerController pc;
    private GravitySuitTrigger gravitySuitTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        gravitySuitTrigger = this.GetComponent<GravitySuitTrigger>();
        gravitySuitTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gravitySuitTrigger.enabled = true;
            gravitySuitTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        gravitySuitTutorial.SetActive(false);
        gravitySuitTrigger.enabled = false;
    }
}
