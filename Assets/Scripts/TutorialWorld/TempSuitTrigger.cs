using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSuitTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject tempSuitTutorial;

    private PlayerController pc;
    private TempSuitTrigger tempSuitTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        tempSuitTrigger = this.GetComponent<TempSuitTrigger>();
        tempSuitTrigger.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tempSuitTrigger.enabled = true;
            tempSuitTutorial.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        tempSuitTutorial.SetActive(false);
        tempSuitTrigger.enabled = false;
    }
}
