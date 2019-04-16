using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject splat;

    public void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Water"))
        {
            if (!collision.gameObject.CompareTag("Enemy"))
            {
                Instantiate(splat, transform);
                Destroy(this.gameObject);
            }

            if (collision.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
