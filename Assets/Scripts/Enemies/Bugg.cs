using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Bugg : Enemy
{

    public Vector3[] targets;
    public int point;
    Animator animator;
    private bool isDead;
    private Vector3 target;
    NavMeshAgent nav;
    private int timer; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        nav = this.GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer == 0)
        {
            point++;
            timer = 300;
        }
        timer--;
        if (point == targets.Length)
            point = 0;
        if (enemyHP <= 0)
        {
            animator.SetBool("IsDead", true);
            isDead = true;
            Destroy(gameObject, 2);
        }
        if (!isDead)
        {

            if (Vector3.Distance(transform.position, pc.transform.position) > 10) {
                gameObject.GetComponent<SphereCollider>().enabled = false;
                Patrol();
            }
            else
                Attack();
        }
        SetDestination();
    }
    void SetDestination() {
        
        nav.SetDestination(target);
        
    }
    void Patrol()
    {

        //transform.position = Vector3.MoveTowards(transform.position, targets[point], 4.5f * Time.deltaTime);
        if (transform.position == targets[point]) {
            Debug.Log("fuck");
            point++;}
        if (point == targets.Length)
            point = 0;
        /*Vector3 targetDirection = targets[point] - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);*/
         target =targets[point];
       

    }
    void Attack()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
        /*transform.position = Vector3.MoveTowards(transform.position, pc.transform.position, 2.5f * Time.deltaTime);
        Vector3 targetDirection = pc.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);*/
        target = pc.transform.position;
    }
}
