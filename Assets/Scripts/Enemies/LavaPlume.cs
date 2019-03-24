using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlume : Enemy
{
    Animator animator;
    public GameObject EnemyBullet;
    public GameObject BulletPoint;
    private double timer;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (enemyHP <= 0)
        {
            animator.SetBool("IsDead", true);
            isDead = true;
            Destroy(gameObject, 1);
        }
        if (Vector3.Distance(transform.position, pc.transform.position) < 50 && !isDead&&timer<=0)
        {
            Attack();

        }

    }

    void Attack()
    {
        animator.SetBool("IsAttacking", true);     
        GameObject EBullet = Instantiate(EnemyBullet, new Vector3(BulletPoint.transform.position.x, BulletPoint.transform.position.y, BulletPoint.transform.position.z), Quaternion.identity);
        //EBullet.GetComponent<Rigidbody>().velocity = transform.up * 10.5f;
        Destroy(EBullet, 20);
        timer = 100;
    }
}
