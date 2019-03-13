using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTexts : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;

    private WarningTexts warning;

    public GameObject textObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        warning = this.GetComponent<WarningTexts>();
        warning.enabled = false;
    }

    void Update()
    {
        textObject.SetActive(true);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !pc.tempSuit)
        {
            textObject.SetActive(true);
            warning.enabled = true;
        }

        else
        {
            textObject.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
        warning.enabled = false;
    }
}
