using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject splat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Water"))
        {
            if (!collision.gameObject.CompareTag("Enemy"))
            {
                Instantiate(splat, transform);
            }

            if (collision.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
