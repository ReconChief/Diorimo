using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyromancer : Enemy
{

    public Vector3[] targets;
    public int point;
    Animator animator;
    public GameObject EnemyBullet;
    public GameObject BulletPoint;
    private int timer;
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
        }
        if (Vector3.Distance(transform.position, pc.transform.position) > 10&& timer <= 0 )
            Patrol();
        else
            Attack();

    }

    void Patrol()
    {
        animator.SetBool("IsAttacking", false);

        transform.position = Vector3.MoveTowards(transform.position, targets[point], 4.5f * Time.deltaTime);
        if (transform.position == targets[point])
            point++;
        if (point == targets.Length)
            point = 0;
        Vector3 targetDirection = targets[point] - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);

    }
    void Attack()
    {
        animator.SetBool("Aiming", true);
        Vector3 adjust = new Vector3(0, 0.5f, 0);
        Vector3 targetDirection = pc.transform.position - transform.position - adjust;
        transform.rotation = Quaternion.LookRotation(targetDirection);
        GameObject EBullet = Instantiate(EnemyBullet, new Vector3(BulletPoint.transform.position.x, BulletPoint.transform.position.y, BulletPoint.transform.position.z), Quaternion.identity);
        EBullet.GetComponent<Rigidbody>().velocity = transform.forward * 20.5f;
        Destroy(EBullet, 3);
        timer = 350;
    }
}
