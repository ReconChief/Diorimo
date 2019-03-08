using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillaFish : Enemy
{

    public Vector3[] targets;
    public int point;
    Animator animator;
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
        if (enemyHP <= 0)
        {
            animator.SetBool("IsDead", true);
            isDead = true;
            Destroy(gameObject, 2);
        }
        if (!isDead)
        {

            if (Vector3.Distance(transform.position, pc.transform.position) > 10)
                Patrol();
            else
                Attack();
        }
    }

    void Patrol()
    {
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
        transform.position = Vector3.MoveTowards(transform.position, pc.transform.position, 2.5f * Time.deltaTime);
        Vector3 targetDirection = pc.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }
}
