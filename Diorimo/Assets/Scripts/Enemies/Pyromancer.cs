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
    public GameObject target;
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
            Destroy(gameObject,1);
        }
        if (Vector3.Distance(transform.position, pc.transform.position) > 20&&!isDead)
        {
            Patrol();

        }

        else if (timer<=0&&!isDead)
        {
            animator.SetBool("Aiming", true);

            Attack();
        }
       


    }

    void Patrol()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("Aiming", false);
        transform.position = Vector3.MoveTowards(transform.position, targets[point], 1.5f * Time.deltaTime);
        if (transform.position == targets[point])
            point++;
        if (point == targets.Length)
            point = 0;
        Vector3 targetDirection = targets[point] - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);

    }
    void Attack()
    {
        animator.SetBool("IsAttacking", true);


        Vector3 adjust = new Vector3(1.5f, 0,0 );
        Vector3 targetDirection = target.transform.position - transform.position-adjust;
        transform.rotation = Quaternion.LookRotation(targetDirection);
        GameObject EBullet = Instantiate(EnemyBullet, new Vector3(BulletPoint.transform.position.x, BulletPoint.transform.position.y, BulletPoint.transform.position.z), Quaternion.identity);
        EBullet.GetComponent<Rigidbody>().velocity = transform.forward * 10.5f;
        Destroy(EBullet, 3);
        timer = 55;
    }
}
