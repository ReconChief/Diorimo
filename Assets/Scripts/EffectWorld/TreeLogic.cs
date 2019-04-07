using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLogic : MonoBehaviour
{
    public GameObject fire;
    private int timer=300;
    private bool burning;
    private bool burned;
    public Material charred;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        //trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (burning&&timer>-5) {
            timer--;
        }
        if (timer == 0&&burned) {
           
            gameObject.GetComponent<MeshRenderer>().material= charred;
                }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireBeam"))
        {
            
            burning = true;
           
            if (!burned) {
                Instantiate(fire, transform);
                burned = true;

            }
            
        }
    }
}
