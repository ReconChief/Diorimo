using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlForest : MonoBehaviour
{
    public GameObject ForestArea;
    public AudioSource ForestMusic;
    
    void Start()
    {
        ForestArea.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ForestArea.SetActive(true);
            ForestMusic.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ForestArea.SetActive(false);
            ForestMusic.Stop();
        }
    }
}
