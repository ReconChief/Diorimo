using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugg : MonoBehaviour
{
    public GameObject player;
    public Vector3[] targets;
    public int point;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targets[point], 4.5f * Time.deltaTime);
        if (transform.position == targets[point])
            point++;
        if (point == targets.Length)
            point = 0;
        Vector3 targetDirection = targets[point] - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }
}
