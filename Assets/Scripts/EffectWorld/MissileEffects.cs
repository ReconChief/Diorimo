using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEffects : MonoBehaviour
{
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) {
            Instantiate(fire, transform);
            transform.localScale = transform.localScale * 0.00025f;
        }
        
    }
}
