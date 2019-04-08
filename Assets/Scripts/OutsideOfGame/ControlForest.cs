using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlForest : MonoBehaviour
{
    public GameObject ForestArea;
    
    void Start()
    {
        ForestArea.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ForestArea.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        ForestArea.SetActive(false);
    }
}
