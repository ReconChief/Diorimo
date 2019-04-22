using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlant : Enemy
{
   
    public GameObject EnemyBullet;
    public GameObject BulletPoint;
    public GameObject target;
    private int timer;
    private Animator anim;
    public bool isDead=false;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        isPlant = true;
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (enemyHP <= 0)
        {anim.SetBool("IsDead", true);
            isDead = true;
            Destroy(gameObject, 3);
            //Animation Dying = gameObject.GetComponent<Animation>();
            //Destroy(this.gameObject,Dying.clip.length);
        }
        timer--;

        if (Vector3.Distance(transform.position, pc.transform.position) < 10f && timer <= 0 && !isDead)
        {
            Attack();
            //isAttacking = false;
        }
        if (Vector3.Distance(transform.position, pc.transform.position) > 10f && timer <= 0 && !isDead)
            anim.SetBool("IsAttacking", false);

    }
    void Attack() {
        anim.SetBool("IsAttacking",true);
        Vector3 adjust = new Vector3(0, 0f, 0);
        //dolphins need 1.5
        Vector3 targetDirection = pc.transform.position- transform.position-adjust;
        transform.rotation = Quaternion.LookRotation(targetDirection);
        GameObject EBullet=Instantiate(EnemyBullet, new Vector3(BulletPoint.transform.position.x, BulletPoint.transform.position.y, BulletPoint.transform.position.z),Quaternion.identity);
        EBullet.GetComponent<Rigidbody>().velocity = transform.forward * 20.5f;
        Destroy(EBullet, 3);
        timer = 120;
    }
}
