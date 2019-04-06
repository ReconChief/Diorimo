using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLogic : MonoBehaviour
{
    public GameObject miniRocks;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            Instantiate(miniRocks, transform);
            Vector3 jerk = new Vector3(5, 0, 0);
            rb.AddForce(jerk, ForceMode.Impulse);
            Destroy(other.gameObject);
        }
    }
}
