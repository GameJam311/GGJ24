using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public int targetDistance;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + targetDistance, startPos.z);
    }

    void Update()
    {
        float Movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, Movement);

        if (transform.position == endPos)
        {
            // eger hedefe ulastiysa geri don
            Vector3 temp = endPos;
            endPos = startPos;
            startPos = temp;
        }
    }
}
