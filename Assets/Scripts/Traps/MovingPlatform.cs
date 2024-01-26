using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f;

    public Transform startPos;
    public Transform endPos;

    private Transform target;
    private void Start()
    {
        target = endPos;
    }
    void Update()
    {
        float Movement = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, Movement);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < 0.01f)
        {
            ChangeDirection();
        }
    }
    void ChangeDirection()
    {
        if(target == endPos)
        {
            target = startPos;
        }
        else
        {
            target = endPos;
        }
    }
}
