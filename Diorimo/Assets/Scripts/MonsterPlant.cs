using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlant : Enemy
{
   
    public GameObject EnemyBullet;
    public GameObject BulletPoint;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
        timer--;
        if (Vector3.Distance(transform.position, pc.transform.position) < 50&&timer<=0)
            Attack();
    }
    void Attack() {
        Vector3 adjust = new Vector3(0, 2, 0);
        Vector3 targetDirection = pc.transform.position- transform.position-adjust;
        transform.rotation = Quaternion.LookRotation(targetDirection);
        GameObject EBullet=Instantiate(EnemyBullet, new Vector3(BulletPoint.transform.position.x, BulletPoint.transform.position.y, BulletPoint.transform.position.z),Quaternion.identity);
        EBullet.GetComponent<Rigidbody>().velocity = transform.forward * 20.5f;
        Destroy(EBullet, 1);
        timer = 120;
    }
}
